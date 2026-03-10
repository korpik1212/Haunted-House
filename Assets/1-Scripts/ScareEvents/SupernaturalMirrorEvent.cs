using System.Collections.Generic;
using UnityEngine;

public class SupernaturalMirrorEvent : ScareEvent
{
    public SupernaturalMirrorEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Supernatural Mirror Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.PARANOIA,60);
        //todo animate event
        return result;
    }
}
