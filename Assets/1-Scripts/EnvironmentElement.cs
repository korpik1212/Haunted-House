using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnvironmentElement : MonoBehaviour, ICardTargetable,IHoverable
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

    private List<EventParent> _events;

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
    public bool checkTimeSlotAvailability(EventParent eventToAssign)
    {
        bool available = false;
        //check if the event's duration conflicts with any event in the "Events" List
        return available;
    }

    public void DoSimulationStep()
    {
        foreach (EventParent eventParent in _events)
        {
            //MAKE EVENT DO ITS THING
        }
    }

    private bool checkTimeSlotAvailability(EventParent eventToAssign)
    {
        bool available = false;
        //check if the event's duration conflicts with any event in the "Events" List
        return available;
    }

    public void OnTargetClick(Card card)
    {
        Debug.Log("got target clicked");
        TimeAndEventHandler.instance.GenerateEvent(card.CardType, this);
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
