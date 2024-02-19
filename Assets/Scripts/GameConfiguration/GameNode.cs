using System.Collections.Generic;

namespace GameConfiguration
{
    // Задание: добавить нужные поля после анализа структуры JSON файла
    [System.Serializable]
    public class GameNodes
    {
        public List<GameNode> nodes;
    }
    
    [System.Serializable]
    public class GameNode
    {
        public int id;
        public Location location;
        public List<DialogNode> dialogs;
    }
    
    [System.Serializable]
    public class DialogNode
    {
        public int id;
        public string text;
        public List<DialogVariant> variants;
    }

    [System.Serializable]
    public class DialogVariant
    {
        public int id;
        public string text;
        public int to;
        public List<FunctionExecuteData> conditions;
        public List<FunctionExecuteData> actions;
    }
    
    [System.Serializable]
    public class FunctionExecuteData
    {
        public string name;
        public int[] parameters;
    }
    
    [System.Serializable]
    public class Location
    {
        public int background;
        public int character;
        public int item;
        public int[] decorations;
    }
}