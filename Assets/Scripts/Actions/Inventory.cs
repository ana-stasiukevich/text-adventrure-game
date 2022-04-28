using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(TextController controller, string noun)
    {
        if (controller.player.inventory.Count == 0)
        {
            controller.currentText.text = "You have nothing\n" ;
            return;
        }

        string result = "You have ";

        bool first = true;
        bool second = false;

        foreach (Item item in controller.player.inventory)
        {
            if (first)
            {
                result += " a " + item.itemName;
                first = false;
                second = true;
            }

            else if (second)
            {
                result += " and a " + item.itemName;
                second = false;
            }

            else
                result += ", a " + item.itemName;
        }

        controller.currentText.text = result + "\n";
    }
}
