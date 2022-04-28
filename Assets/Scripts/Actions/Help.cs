using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(TextController controller, string noun)
    {
        controller.currentText.text = "Type a verb followed by a noun (e.g. \"go north\")";
        controller.currentText.text += "\nAllowed verbs: Go, Examine, Get, Give, Use, TalkTo, Say, Read";
        controller.currentText.text += "\nYou can also access Inventory and Help";
        controller.currentText.text += "\nIt doesn't matter if you use upper- or lowercase letters.";
    }
}
