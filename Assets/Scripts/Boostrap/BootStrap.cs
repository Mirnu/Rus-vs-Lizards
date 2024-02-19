using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    private JsonConfig _config;
    private DialogModel _dialogModel;
    private DialogPresenter _dialogPresenter;

    [Header("Config")]
    [SerializeField] private TextAsset _startCharacteristicsFile;
    [SerializeField] private TextAsset _gameConfigFile;

    [Header("UI")]
    [SerializeField] private DialogView _dialogView;

    private void Awake()
    {
        initConfig();
        initDialog();
    }
    private void initConfig()
    {
        _config = new JsonConfig(_startCharacteristicsFile, _gameConfigFile);
        _config.Initialize();
    }
    private void initDialog()
    {
        _dialogModel = new DialogModel(_dialogView, _config);
        _dialogPresenter = new DialogPresenter(_dialogModel);
        _dialogView.Init(_dialogPresenter);
        _dialogPresenter.Start();
    }
}
