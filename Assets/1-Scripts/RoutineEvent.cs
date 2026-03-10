using System;
using UnityEngine;

public abstract class RoutineEvent : Event
{
    
    public GameObject destinationRoom;
    
    public abstract void DoAdditionalEffect(Room room, Human human);
    
}
