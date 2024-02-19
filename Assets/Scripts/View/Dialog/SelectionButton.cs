using GameConfiguration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SelectionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text TextLabel;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Init(DialogVariant variant, Action<DialogVariant> onClick)
    {
        TextLabel.text = variant.text;
        _button.onClick.AddListener(() => onClick(variant));
    }
}
