using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageButton : MonoBehaviour
{
    public void SetText(string msg)
    {
        GetComponentInChildren<TMP_Text>().text = msg;
    }

    public void RemoveButton()
    {
        Destroy(gameObject);
    }
}
