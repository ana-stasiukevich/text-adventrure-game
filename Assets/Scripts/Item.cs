using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;
    public bool playerCanReadFrom = false;
    public bool playerCanTalkTo = false;
    public bool playerCanGiveTo = false;
    public bool itemEnabled = true;

    public Interaction[] interactions;

    public Item targetItem = null;

    public bool InteractWith(TextController controller, string actionKeyword, string noun = "")
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.action.keyword == actionKeyword)
            {
                if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                continue;

                foreach (Item disableItem in interaction.itemsToDisable)
                {
                    disableItem.itemEnabled = false;
                }

                foreach(Item enableItem in interaction.itemsToEnable)
                {
                    enableItem.itemEnabled = true;
                }

                foreach(Connection disableConnection in interaction.connectionsToDisable)
                {
                    disableConnection.connectionEnabled = false;
                }

                foreach(Connection enableConnection in interaction.connectionsToEnable)
                {
                    enableConnection.connectionEnabled = true;
                }

                if(interaction.teleportLocation != null)
                {
                    controller.player.Teleport(interaction.teleportLocation);
                }

                controller.currentText.text = interaction.responce;
                controller.DisplayLocation(true);

                return true;
            }            
        }

        return false;
    }
}
