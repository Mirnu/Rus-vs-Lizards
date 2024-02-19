using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameConfiguration;

public class DialogView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _answerButtons;
    [SerializeField] private TMP_Text _titleLabel;

    [Header("Prefabs")]
    [SerializeField] private GameObject _answerButton;

    [Header("Config")]
    [SerializeField] private int _offset = 2;

    private DialogNode _dialog;
    private DialogPresenter _presenter;
    private List<GameObject> _buttons = new List<GameObject>();

    public void Init(DialogPresenter presenter)
    {
        _presenter = presenter;
    }

    public void Display(DialogNode dialog)
    {
        _dialog = dialog;
        changeTitle();
        initButtons();
    }

    private void initButtons()
    {
        _buttons.ForEach(button => Destroy(button));
        _buttons.Clear();
        for(int i = 0; i < _dialog.variants.Count; i++)
        {
            instantiateButton(i, _dialog.variants[i]);
        }
    }

    private void onClick(DialogVariant variant)
    {
        _presenter.OptionSelected(variant);
    }

    private void instantiateButton(int id, DialogVariant dialogVariant)
    {
        GameObject button = Instantiate(_answerButton, _answerButtons.transform);
        button.transform.position -= Vector3.up * id * _offset;
        _buttons.Add(button);
        
        SelectionButton selectionButton = button.GetComponent<SelectionButton>();
        selectionButton.Init(dialogVariant, onClick);
    }

    private void changeTitle()
    {
        _titleLabel.text = _dialog.text;
    }
  
}