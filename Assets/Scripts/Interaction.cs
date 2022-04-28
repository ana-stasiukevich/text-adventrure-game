using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    public Action action;

    [TextArea]
    public string responce;

    public string textToMatch;

    public List<Item> itemsToDisable = new();
    public List<Item> itemsToEnable = new();

    public List<Connection> connectionsToDisable = new();
    public List<Connection> connectionsToEnable = new();

    public Location teleportLocation;
}
