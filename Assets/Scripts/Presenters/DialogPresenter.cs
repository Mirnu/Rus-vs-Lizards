using GameConfiguration;
using Unity.VisualScripting;

public class DialogPresenter
{
    private DialogModel _dialogModel;

    public DialogPresenter(DialogModel dialogModel)
    {
        _dialogModel = dialogModel;
    }

    public void Start()
    {
        OptionSelected(_dialogModel.CurrentDialog.variants[0]);
    }

    public void OptionSelected(DialogVariant variant)
    {
        _dialogModel.ChangeDialog(variant.to);
    }
}
