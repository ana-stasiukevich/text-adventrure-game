using UnityEngine;

public abstract class Action : ScriptableObject
{
    [SerializeField]
    internal string keyword;
    public abstract void RespondToInput(TextController controller, string noun);
}
