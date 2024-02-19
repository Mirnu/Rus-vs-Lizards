using GameConfiguration;
using System.Collections.Generic;

public class DialogModel
{
    public DialogNode CurrentDialog;

    private DialogView _dialogView;
    private JsonConfig _config;
    private List<GameNode> _nodes => _config.GameNodes.nodes;


    public DialogModel(DialogView dialogView, JsonConfig config)
    {
        _dialogView = dialogView;
        _config = config;
        CurrentDialog = _nodes[0].dialogs[0];
    }

    public void ChangeDialog(int id)
    {
        GameNode gameNode = _nodes.Find(n =>
           n.dialogs.Find(d => d.id == id) != null);
        if (gameNode == null) return;
        DialogNode dialogNode = gameNode.dialogs.Find(d => d.id == id);
        if (dialogNode == null) return;
        CurrentDialog = dialogNode;
        _dialogView.Display(dialogNode);
    }
}
