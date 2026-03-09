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
public class EnvironmentElement : MonoBehaviour
{
    // Environment Element
    // * Events<>
    // * functionality to check time availability and other shit()

    private ScareEvent Trap = null;

    public EnvironmentElementType type;
    

    public void DoSimulationStep()
    {
        
    }

    public void setTrap(ScareEvent e)
    {
        Trap = e;
    }
    
    public bool checkTimeSlotAvailability()
    {
     return Trap != null;
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
