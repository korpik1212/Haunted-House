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
public interface EventParent 
{
    // Event - Interface
    // * Scare card{}
    // * Environment Element
    // * Duration time
    // * Start time
    // * Scare Type Values() returning a map<Key is Enum, Value is Integer>
    
    public abstract DateTime getStartTime();
    public abstract TimeSpan getDuration();
    public abstract EnvironmentElement getHost();
    public abstract ScareCard getCard();
    public abstract Dictionary<ScareType, int> spook();

}
