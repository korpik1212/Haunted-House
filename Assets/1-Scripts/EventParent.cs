using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum ScareCard
{
    POLTERGEIST,
    ENVIORMENTALGHOST,
    SPIDER
}

public enum ScareType
{
    SHOCK,
    DISGUST,
    PARANOIA
}
public abstract class EventParent 
{

    private DateTime startTime;
    private TimeSpan duration;
    private EnvironmentElement hostObject;
    private ScareCard scareCard;
    public EventParent(DateTime sT, TimeSpan d, EnvironmentElement h, ScareCard c)
    {
        startTime = sT;
        duration = d;
        hostObject = h;
        scareCard = c;
    }

    public DateTime getStartTime()
    {
        return startTime;
    }

    public TimeSpan getDuration()
    {
        return duration;
    }

    public EnvironmentElement getHost()
    {
        return hostObject;
    }

    public ScareCard getCard()
    {
        return scareCard;
    }
    public abstract Dictionary<ScareType, int> spook();

}
