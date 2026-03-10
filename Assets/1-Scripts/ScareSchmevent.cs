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
public abstract class ScareSchmevent : Schmevent
{
    private EnvironmentElement hostObject;
    public ScareSchmevent(EnvironmentElement h)
    {
        hostObject = h;
    }
    public EnvironmentElement getHost()
    {
        return hostObject;
    }
    public abstract Dictionary<ScareType, int> spook(Human human);
}
