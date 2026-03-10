using System.Collections.Generic;
using UnityEngine;
public enum ScareCard
{
    RAT,
    SPIDER,
    SUPERNATURAL,
    DECAY
}

public enum ScareType
{
    SHOCK,
    DISGUST,
    PARANOIA
}
public abstract class ScareEvent : Event
{
    private EnvironmentElement hostObject;
    public ScareEvent(EnvironmentElement h)
    {
        hostObject = h;
    }
    public EnvironmentElement getHost()
    {
        return hostObject;
    }
    public abstract Dictionary<ScareType, int> spook();
}
