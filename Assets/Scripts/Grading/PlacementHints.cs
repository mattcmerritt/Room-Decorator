using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlacementHints : MonoBehaviour
{
    /*
     * (0) on start => Hey, thanks for helping me with this! Remember, I'm looking for a workdesk and a library in the office.
     * 
     * (1) on desk/table place, good color => That desk looks great! Can you give me a matching chair as well?
     * (2) on desk/table place, bad color => Can you use a less distracting color for that desk?
     * 
     * (3) on bookshelf place, good color => That bookshelf looks great for my office! Can you put it away from my desk so I have plenty of space?
     * (4) on bookshelf place, bad color => That bookshelf is a bit boring. Maybe make it pop a bit more?
     * 
     * (5) on seat place, bad color => That seat color's too bland, is there something more interesting you can use?
     * 
     * time intervals
     * 
     * (6) if no desk => For the workdesk, any sort of table works - as long as it can hold papers and a computer I should be fine.
     * (7) if no bookshelf => For the library, I think a vibrant bookshelf would be interesting. Surprise me with the color!
     * (8) if less than 2 seats => Near the library, can you put out a couple seats to relax in? I'd like some space for me and a friend to relax.
     */

    // some sort of object for the text bubble

    // since we don't want to sent repeat messages, track to see if they were already sent
    private bool[] wasSentAlready;
    // timer to keep track of when to send the other hints
    private float HintTimer;
    [SerializeField] private TMP_Text NewMessageBox;
    [SerializeField] private MessageAligner Phone;

    private void Start()
    {
        wasSentAlready = new bool[] { false, false, false, false, false, false, false, false, false };
        // send hint 0 at game start
        ShowHint("Hey, thanks for helping me with this! Remember, I'm looking for a workdesk and a library in the office.");
        wasSentAlready[0] = true;
        HintTimer = 30f;
    }

    private void Update()
    {
        HintTimer -= Time.deltaTime;
        if(HintTimer <= 0)
        {
            if (!wasSentAlready[6])
            {
                ShowHint("For the workdesk, any sort of table works - as long as it can hold papers and a computer I should be fine.");
                wasSentAlready[6] = true;
                ResetHintTimer();
            }
            else if (!wasSentAlready[7])
            {
                ShowHint("For the library, I think a vibrant bookshelf would be interesting. Surprise me with the color!");
                wasSentAlready[7] = true;
                ResetHintTimer();
            }
            else if (!wasSentAlready[8])
            {
                ShowHint("Near the library, can you put out a couple seats to relax in? I'd like some space for me and a friend to relax.");
                wasSentAlready[8] = true;
                ResetHintTimer();
            }
            // else all the messages were sent already, so do nothing.
        }
    }

    public void LookForPlacementHint(Furniture placed)
    {
        if (placed.GetLabel() == "Desk" || placed.GetLabel() == "Table")
        {
            if (IsProfessionalColor(placed.GetColorName()) && !wasSentAlready[1])
            {
                ShowHint("That desk looks great! Can you give me a matching chair as well?");
                wasSentAlready[1] = true;
                wasSentAlready[6] = true; // skip desk generic
                ResetHintTimer();
            }
            else if (!wasSentAlready[2])
            {
                ShowHint("Can you use a less distracting color for that desk?");
                wasSentAlready[2] = true;
                ResetHintTimer();
            }
        }

        if (placed.GetLabel() == "Bookshelf")
        {
            if (IsVibrantColor(placed.GetColorName()) && !wasSentAlready[3])
            {
                ShowHint("That bookshelf looks great for my office! Can you put it away from my desk so I have plenty of space?");
                wasSentAlready[3] = true;
                wasSentAlready[7] = true; // skip bookshelf generic
                ResetHintTimer();
            }
            else if (!wasSentAlready[4])
            {
                ShowHint("That bookshelf is a bit boring. Maybe pick a color that will make it pop a bit more?");
                wasSentAlready[4] = true;
                ResetHintTimer();
            }
        }

        if (placed.GetLabel() == "Sofa" || placed.GetLabel() == "Loveseat")
        {
            if (!IsVibrantColor(placed.GetColorName()) && !wasSentAlready[5])
            {
                ShowHint("That seat color's too bland, is there something more interesting you can use?");
                wasSentAlready[5] = true;
                ResetHintTimer();
            }
        }
    }

    private void ResetHintTimer()
    {
        if (!wasSentAlready[6])
        {
            HintTimer = 30f;
        }
        else if (!wasSentAlready[7])
        {
            HintTimer = 45f;
        }
        else if (!wasSentAlready[8])
        {
            HintTimer = 45f;
        }
        // if none of the conditions are true, the timer doesn't matter anymore.
    }

    private bool IsVibrantColor(string color)
    {
        return (color == "red" || color == "yellow" || color == "green" || color == "blue" || color == "purple");
    }

    private bool IsProfessionalColor(string color)
    {
        return (color == "orange" || color == "brown" || color == "white");
    }

    private void ShowHint(string hintMessage)
    {
        FindObjectOfType<PlacementHints>().NewMessageBox.text = "New message:\n" + hintMessage;
        Phone.AddMessage(hintMessage, false);
    }
}
