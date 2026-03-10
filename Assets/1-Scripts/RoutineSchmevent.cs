using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class RoutineSchmevent : Schmevent
{
    [Header("Start Time")]
    [Range(0, 23)] public int startTimeHour;
    [Range(0,59)] public int startTimeMinute;
    [Header("Duration")] 
    [Range(0, 24 * 60)] public int durationInTicks;
    public Room destinationRoom;
    public AdditionalEffect additionalEffect;

    
    
    public void SetupRoutineEvent()
    {
        startTime = new DateTime(2026, 1, 1, startTimeHour, startTimeMinute, 0);
        duration = TimeSpan.FromMinutes(durationInTicks*TimeAndEventHandler.getInstance().increment.Minutes);
        Debug.Log("Setting up routine event. Duration: " + duration+" Start time: "+startTime);
    }
    


}
