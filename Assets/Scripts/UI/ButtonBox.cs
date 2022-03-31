using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonBox : MonoBehaviour
{
    [SerializeField]
    private List<string> Messages;
    [SerializeField]
    private List<string> Responses;
    [SerializeField]
    private GameObject ButtonPrefab;

    private void Awake()
    {
        for (int i = 0; i < Messages.Count; i++)
        {
            GameObject buttonObj = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity);
            buttonObj.transform.SetParent(transform);
            MessageButton buttonScript = buttonObj.GetComponent<MessageButton>();
            buttonScript.SetText(Messages[i]);

            string currentMsg = Messages[i], currentResp = Responses[i];

            Button button = buttonObj.GetComponent<Button>();
            UnityAction sendMessages = () =>
            {
                MessageAligner messageBox = FindObjectOfType<MessageAligner>();
                // sending the message from the button as player
                messageBox.AddMessage(currentMsg, true);
                // sending the response from the button as client
                messageBox.AddMessage(currentResp, false);
            };

            UnityAction removeButton = () =>
            {
                buttonScript.RemoveButton();
            };

            button.onClick.AddListener(sendMessages);
            button.onClick.AddListener(removeButton);
        }
    }

    private void Update()
    {
        ChatBubble[] bubbles = GetComponentsInChildren<ChatBubble>();

        float minSize = 0f;
        foreach (ChatBubble option in bubbles)
        {
            minSize += option.GetHeight();
        }

        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width, minSize);
    }
}
