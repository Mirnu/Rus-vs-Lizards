using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [HideInInspector] public JsonConfig Config;
    [HideInInspector] public DialogModel DialogModel;
    [HideInInspector] public DialogView DialogView;

    [SerializeField] private TextAsset _startCharacteristicsFile;
    [SerializeField] private TextAsset _gameConfigFile;

    private void Awake()
    {
        initConfig();
        DialogView = new DialogView();
        DialogModel = new DialogModel(DialogView, Config.GameNodes.nodes, Config);
    }

    private void initConfig()
    {
        Config = new JsonConfig(_startCharacteristicsFile, _gameConfigFile);
        Config.Initialize();
    }
}
