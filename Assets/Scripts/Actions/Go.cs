using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Go")]
public class Go : Action
{
    public override void RespondToInput(TextController controller, string noun)
    {
        if (controller.player.ChangeLocation(noun))
        {
            controller.DisplayLocation();
        }

        else
        {
            controller.currentText.text = "You can't go that way\n";
        }
    }
}
