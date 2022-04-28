using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;
    public List<Item> inventory = new();

    public bool ChangeLocation(string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if (connection != null)
        {
            if (connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }

        return false;
    }

    internal bool CanGiveToItem(Item item)
    {
        return item.playerCanGiveTo;
    }

    internal bool CanReadFromItem( Item item)
    {
        return item.playerCanReadFrom;
    }

    internal bool CanTalkToItem(Item item)
    {
        return item.playerCanTalkTo;
    }

    public void Teleport(Location destination)
    {
        currentLocation = destination;
    }

    internal bool CanUseItem(Item item)
    {
        if (item.targetItem == null)
            return true;

        if (HasItem(item.targetItem))
            return true;

        if(currentLocation.HasItem(item.targetItem))
            return true;

        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in inventory)
        {
            if (item == itemToCheck && item.itemEnabled)
            return true;
        }

        return false;
    }
    internal bool HasItemByName(string noun)
    {
        foreach (Item item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
                return true;
        }

        return false;
    }
}
