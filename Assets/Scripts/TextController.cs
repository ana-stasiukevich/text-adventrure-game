using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TMP_InputField textEntryField;
    public TMP_Text historyText;
    public TMP_Text currentText;

    public Player player;

    public Action[] actions;

    [TextArea]
    [SerializeField] string introText;

    void Start()
    {
        historyText.text = introText;
        DisplayLocation();
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = "\n"+ player.currentLocation.description +"\n";
        description += "\n" + player.currentLocation.GetConnectionsText();
        description += player.currentLocation.GetItemsText();

        if (additive)
        {
            currentText.text += "\n" + description;
        }
        else
            currentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrenttext();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
    }
    void LogCurrenttext()
    {
        historyText.text += "\n\n";
        historyText.text +=currentText.text;

        historyText.text += "\n\n";
        historyText.text += "<color=#aaccaaff>" +textEntryField.text;
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();
        char[] delimiter = {' '};
        string[] seperatedWords = input.Split(delimiter);

        foreach(Action action in actions)
        {
            if (action.keyword.ToLower() == seperatedWords[0])
            {
                if (seperatedWords.Length>1)
                {
                    action.RespondToInput(this, seperatedWords[1]);
                }

                else
                {
                    action.RespondToInput(this, "");
                }

                return;
            }
        }

        currentText.text = "Nothing happens! (having trouble? type Help)";
    }
}
