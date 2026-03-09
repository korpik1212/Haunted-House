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

    private List<Event> events;

    public EnvironmentElementType type;
    public bool addEvent(Event spookEvent)
    {
        if (checkTimeSlotAvailability(spookEvent))
        {
            events.Add(spookEvent);
            return true;
        }
        return false;
    }

    public void DoSimulationStep()
    {
        foreach (Event Event in events)
        {
            //MAKE EVENT DO ITS THING
        }
    }

    private bool checkTimeSlotAvailability(Event eventToAssign)
    {
        bool available = false;
        //check if the event's duration conflicts with any event in the "Events" List
        return available;
    }

    public void OnTargetClick(Card card)
    {
        Debug.Log("got target clicked");
        TimeAndEventHandler.instance.AssignEvent(card.CardType, this);
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
