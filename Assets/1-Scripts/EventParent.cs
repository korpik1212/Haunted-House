using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public abstract class Event : ScriptableObject
{
    private DateTime startTime;
    private TimeSpan duration;

    public void setStartTime(DateTime time)
    {
        startTime = time;
    }
    
    public DateTime getStartTime()
    {
        return startTime;
    }

    public TimeSpan getDuration()
    {
        return duration;
    }
}
