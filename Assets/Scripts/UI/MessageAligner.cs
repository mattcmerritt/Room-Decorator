using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAligner : MonoBehaviour
{
    private List<ChatBubble> Messages = new List<ChatBubble>();
    [SerializeField]
    private List<string> PreloadedMessages;
    [SerializeField]
    private List<bool> IsPlayer;

    // message prefabs for preloading
    [SerializeField]
    private GameObject PlayerBubble, ClientBubble;

    private const float SPACE = 5f;

    private void Awake()
    {
        // preloading messages
        for (int i = 0; i < PreloadedMessages.Count; i++)
        {
            AddMessage(PreloadedMessages[i], IsPlayer[i]);
        }
    }

    private void Start()
    {
        // drawing any preloaded bubbles
        RedrawMessages();
    }

    private void Update()
    {
        // drawing any preloaded bubbles
        RedrawMessages();
    }

    public void RedrawMessages()
    {
        float minSize = 0f;
        foreach (ChatBubble msg in Messages)
        {
            msg.CheckSize();
            minSize += msg.GetHeight() + SPACE;
        }

        // stretching box if too small
        if (minSize > GetComponent<RectTransform>().rect.height)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width, minSize);
        }
        
        // drawing elements in the box
        float currentHeight = GetComponent<RectTransform>().rect.height / 2;
        foreach (ChatBubble msg in Messages)
        {
            msg.SetLocation(0f, currentHeight - (msg.GetHeight() / 2));
            currentHeight -= msg.GetHeight() + SPACE;
        }
    }

    public void AddMessage(string msg, bool isPlayer)
    {
        GameObject bubbleObj = Instantiate(isPlayer ? PlayerBubble : ClientBubble, Vector3.zero, Quaternion.identity);
        bubbleObj.transform.SetParent(transform);
        ChatBubble bubble = bubbleObj.GetComponent<ChatBubble>();
        bubble.SetMessage(msg);

        Messages.Add(bubble);
    }
}
