using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RoutineEvent", menuName = "ScriptableObjects/RoutineEvent", order = 1)]

[Serializable]
public class RoutineEvent : Event
{
    [Range(0, 24)] public int hour;
    [Range(0,59)] public int minute;
    private DateTime startTime;
    public GameObject destinationRoom;
    public Func<Room, Human, Null> additionalEffect;
    
    public void setStartTime(DateTime time)
    {
        startTime = time;
    }
    
    public DateTime getStartTime()
    {
        return startTime;
    }

    public void DoAdditionalEffect(Room room, Human human)
    {
        
    }


}
