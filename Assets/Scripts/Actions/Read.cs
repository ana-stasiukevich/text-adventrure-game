using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(TextController controller, string noun)
    {
        if (ReadFromItem(controller, controller.player.currentLocation.items, noun))
            return;

        if (ReadFromItem(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun + " here!\n";
    }

    private bool ReadFromItem(TextController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanReadFromItem(item))
                {
                    if (item.InteractWith(controller, "read"))
                    {
                        return true;
                    }
                }

                controller.currentText.text = "Nothing is written on the " + noun + "\n";
                return true;
            }

            if (string.IsNullOrWhiteSpace(noun))
            {
                controller.currentText.text = "What should be read?" + "\n";
                return true;
            }
        }

        return false;
    }
}
