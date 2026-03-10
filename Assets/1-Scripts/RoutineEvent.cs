using System;
using UnityEngine;

public abstract class RoutineEvent : Event
{
    
    public GameObject destinationRoom;
    public String quote = "";
    
    public abstract void DoAdditionalEffect(Room room, Human human);
    
}
