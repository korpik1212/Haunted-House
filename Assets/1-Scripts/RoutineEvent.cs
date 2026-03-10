using System;
using UnityEngine;

public abstract class RoutineEvent : Event
{
    private DateTime startTime;
    public GameObject destinationRoom;
    
    public void setStartTime(DateTime time)
    {
        startTime = time;
    }
    
    public DateTime getStartTime()
    {
        return startTime;
    }
    public abstract void DoAdditionalEffect(Room room, Human human);
    
}
