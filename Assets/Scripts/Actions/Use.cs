using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
public override void RespondToInput(TextController controller, string noun)
    {
        if(UseItems(controller, controller.player.currentLocation.items, noun))
            return;

        if(UseItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "Nothing happens!\n";
    }

    private bool UseItems(TextController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if(controller.player.CanUseItem(item))
                {
                    if (item.InteractWith(controller, "use"))
                    {
                        return true;
                    }
                }
                
                controller.currentText.text = "The " + noun + " does nothing\n";
                return true;
            }

            if (string.IsNullOrWhiteSpace(noun))
            {        
                controller.currentText.text = "What should be used?\n";
                return true;
            }
        }
        
        return false;
    }
}
