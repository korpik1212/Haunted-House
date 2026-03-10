using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[Serializable]
public abstract class Event : ScriptableObject
{
    public DateTime startTime;
    public TimeSpan duration;

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
