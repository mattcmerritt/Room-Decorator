using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text TimerText;
    [SerializeField] private float RunningTimer;
    [SerializeField] private string Minutes, Seconds;

    private void Start()
    {
        RunningTimer = 0;
    }
    private void Update()
    {
        RunningTimer += Time.deltaTime;
        Minutes = "" + Mathf.Floor(RunningTimer / 60);
        Seconds = Mathf.Floor(RunningTimer % 60) >= 10 ? "" + Mathf.Floor(RunningTimer % 60) : "0" + Mathf.Floor(RunningTimer % 60);
        TimerText.text = $"Time Spent: {Minutes}:{Seconds}";
    }

    public float GetTimerValue()
    {
        return RunningTimer;
    }
}
