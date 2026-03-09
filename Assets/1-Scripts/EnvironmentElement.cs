using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum EnvironmentElementType
{
    MIRROR,
    SINK,
    COUCH
}
public class EnvironmentElement
{
    // Environment Element
    // * Events<>
    // * functionality to check time availability and other shit()

    List<EventParent> Events;
    public EnvironmentElementType type;
    public bool addEvent(EventParent spookEvent)
    {
        if (checkTimeSlotAvailability(spookEvent))
        {
            Events.Add(spookEvent);
            return true;
        }
        return false;
    }
    
    private bool checkTimeSlotAvailability(EventParent eventToAssign)
    {
        bool available = false;
        //check if the event's duration conflicts with any event in the "Events" List
        return available;
    }



}
