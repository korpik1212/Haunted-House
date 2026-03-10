using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RoutineEvent", menuName = "ScriptableObjects/RoutineEvent", order = 1)]

[Serializable]
public class RoutineSchmevent : Schmevent
{
    [Header("Start Time")]
    [Range(0, 23)] public int startTimeHour;
    [Range(0,59)] public int startTimeMinute;
    private DateTime startTime;
    [Header("Duration")] 
    [Range(0, 24 * 60)] public int durationInTicks;
    public TimeSpan duration;
    public Room destinationRoom;
    public AdditionalEffect additionalEffect;

    
    
    public void setupRoutineEvent()
    {
        startTime = new DateTime(2026, 1, 1, startTimeHour, startTimeMinute, 0);
        duration = TimeSpan.FromMinutes(durationInTicks);
    }

    public void setStartTime(DateTime time)
    {
        startTime = time;
    }
    
    public DateTime getStartTime()
    {
        return startTime;
    }
    


}
