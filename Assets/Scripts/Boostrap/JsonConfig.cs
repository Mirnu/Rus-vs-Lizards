using GameConfiguration;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JsonConfig: IInitializable
{
    public PlayerStartInfo PlayerStartInfo;
    public GameNodes GameNodes;

    private TextAsset _startCharacteristicsFile;
    private TextAsset _gameConfigFile;

    public JsonConfig(TextAsset startCharacteristicsFile, TextAsset gameConfigFile) 
    {
        _startCharacteristicsFile = startCharacteristicsFile;
        _gameConfigFile = gameConfigFile;   
    }

    public void Initialize()
    {
        PlayerStartInfo = LoadFromJson<PlayerStartInfo>(_startCharacteristicsFile); 
        GameNodes = LoadFromJson<GameNodes>(_gameConfigFile);
    }

    private T LoadFromJson<T>(TextAsset textAsset)
    {
        T toObject = default;

        if (textAsset)
        {
            string json = textAsset.text;            
            toObject = JsonUtility.FromJson<T>(json);   
        }
        else
            Debug.LogError($"Cannot find asset!");

        return toObject;
    }
}
