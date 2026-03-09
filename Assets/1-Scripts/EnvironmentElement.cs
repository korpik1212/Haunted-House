using System;
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


[System.Serializable]
public class EnvironmentElement
{
    // Environment Element
    // * Events<>
    // * functionality to check time availability and other shit()

    private List<Event> events=new List<Event>();

    public EnvironmentElementType type;
    

    public void DoSimulationStep()
    {
        foreach (Event Event in events)
        {
            //MAKE EVENT DO ITS THING
        }
    }

    public void addEvent(Event e)
    {
        Debug.Log(e);
        e.spook();
        events.Add(e);
    }
    
    public bool checkTimeSlotAvailability(Event eventToAssign)
    {
     return checkTimeSlotAvailability(eventToAssign.getStartTime(), eventToAssign.getDuration());
    }
    public bool checkTimeSlotAvailability(DateTime startTime, TimeSpan duration)
    {
        bool available = true;
        foreach (Event e in events)
        {
            if ((e.getStartTime()>= startTime && e.getStartTime() <= startTime + duration)||e.getStartTime()+e.getDuration() >= startTime)
            {
                available = false;
            }
        }
        return available;
    }
    public void OnTargetClick(Card card)
    {
        Debug.Log("got target clicked");
        //todo here the ui to determine the time should pop up and we should place the selected time into "startTime:DateTime.now"
        TimeAndEventHandler.instance.AssignEvent(card.CardType, this,startTime:DateTime.Now);
    }

    public void OnTargetHoverEnter(Card card)
    {

    }

    public void OnHoverEnter()
    {
        Debug.Log("hoverinn");
    }

    public void OnTargetHoverExit(Card card)
    {
    }

    public void OnHoverExit()
    {
    }

}
