using System.Collections.Generic;
using UnityEngine;
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
public abstract class ScareEvent : Event
{ private EnvironmentElement hostObject;
    private ScareCard scareCard;
    public ScareEvent(EnvironmentElement h, ScareCard c)
    {
        hostObject = h;
        scareCard = c;
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
