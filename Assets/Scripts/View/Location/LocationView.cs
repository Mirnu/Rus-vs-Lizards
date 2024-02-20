using GameConfiguration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private SpriteRenderer _backRenderer;
    [SerializeField] private GameObject _decorationsRenderer;
    [SerializeField] private GameObject _itemRenderer;
    [SerializeField] private GameObject _characterRenderer;

    [Header("Prefabs")]
    [SerializeField] private List<Sprite> _backGrounds;
    [SerializeField] private List<Sprite> _decorations;
    [SerializeField] private List<Sprite> _items;
    [SerializeField] private List<Sprite> _characters;

    private DialogPresenter _presenter;
    private Location _location;

    public void Init(DialogPresenter presenter)
    {
        _presenter = presenter;
    }

    public void Display(Location location)
    {
        _location = location;
        displayBack();
    }

    private void displayBack()
    {
        Sprite backGround = _backGrounds[_location.background];
        if (backGround != null)
            _backRenderer.sprite = backGround;
        else Debug.LogError("BackGrounf is undefined");
    }
}
