using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondToInput(TextController controller, string noun)
    {
        if(CheckItems(controller, controller.player.currentLocation.items, noun))
        return;

        if(CheckItems(controller, controller.player.inventory, noun))
        return;

        controller.currentText.text = "You can't see a " + noun + "\n";
    }

    private bool CheckItems(TextController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (item.InteractWith(controller, "examine"))
                {
                    return true;
                }
                        
                controller.currentText.text = "You see " + item.description + "\n";
                return true;
            }

            if (string.IsNullOrWhiteSpace(noun))
            {        
                controller.currentText.text = "What should be examined?\n";
                return true;
            }
        }

        return false;
    }
}
