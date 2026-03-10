using System;
using UnityEngine;

public class TimeDebug : MonoBehaviour
{
    
    public TMPro.TMP_Text timeText;
    public void onClick()
    {
        TimeAndEventHandler.getInstance().advanceTime();
    }

    public void Update()
    {
        timeText.text = TimeAndEventHandler.getInstance().currentTime.ToLongTimeString();
    }
}
