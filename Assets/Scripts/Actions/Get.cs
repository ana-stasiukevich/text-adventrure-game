using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(TextController controller, string noun)
    {
        foreach(Item item in controller.player.currentLocation.items)
        {
            if (item.enabled && item.itemName == noun)
            {
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = "You take the " + noun + "\n";
                    return;
                }
            }
        }

        controller.currentText.text = "You can't get that\n";
    }
}
