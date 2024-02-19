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
    [SerializeField] private int _offset = 140;

    private Dialog _dialog;

    public void Display(Dialog dialog)
    {
        _dialog = dialog;
        changeTitle();
        initButtons();
    }

    private void initButtons()
    {
        for(int i = 0; i < _dialog.Variants.Count; i++)
        {
            instantiateButton(i, _dialog.Variants[i]);
        }
    }

    private void onClick(DialogVariant variant)
    {
        
    }

    private void instantiateButton(int id, DialogVariant dialogVariant)
    {
        GameObject button = Instantiate(_answerButton, _answerButtons.transform);
        button.transform.position -= Vector3.up * id * _offset;
        
        SelectionButton selectionButton = button.GetComponent<SelectionButton>();
        selectionButton.Init(dialogVariant, onClick);
    }

    private void changeTitle()
    {
        _titleLabel.text = _dialog.title;
    }
  
}

public struct Dialog
{
    public int id;
    public string title;
    public List<DialogVariant> Variants;
}

public struct DialogVariant
{
    public int id;
    public string text;
}
