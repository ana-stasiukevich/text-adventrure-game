using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_InputField textEntryField;
    public TMP_Text historyText;
    public TMP_Text currentText;

    public Player player;

    public Action[] actions;

    [TextArea]
    [SerializeField] string introText;
    // Start is called before the first frame update
    void Start()
    {
        historyText.text = introText;
        textEntryField.ActivateInputField();
        DisplayLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description +"\n";
        description += player.currentLocation.GetConnectionsText();
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
        textEntryField.ActivateInputField();
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
