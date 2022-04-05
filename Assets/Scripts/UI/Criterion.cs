using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Criterion : MonoBehaviour
{
    private TMP_Text Text;
    private Toggle Toggle;

    private string Message;
    private bool IsChecked;

    private void Awake()
    {
        Toggle = GetComponent<Toggle>();
        Toggle.interactable = false;

        Text = GetComponentInChildren<TMP_Text>();

        UpdateContent();
    }

    public void SetText(string msg)
    {
        Message = msg;
    }

    public void SetToggle(bool isChecked)
    {
        IsChecked = isChecked;
    }

    public void SetState(string msg, bool isChecked)
    {
        SetText(msg);
        SetToggle(isChecked);
    }

    private void UpdateContent()
    {
        Text.text = Message;
        Toggle.isOn = IsChecked;
    }
}
