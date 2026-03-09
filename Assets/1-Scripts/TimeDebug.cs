using System;
using UnityEngine;

public class TimeDebug : MonoBehaviour
{
    public TMPro.TMP_Text timeText;
    public void onClick()
    {
        TimeAndEventHandler.instance.advanceTime();
    }

    public void Update()
    {
        timeText.text = TimeAndEventHandler.instance.currentTime.ToLongTimeString();
    }
}
