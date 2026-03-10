using System.Collections.Generic;
using UnityEngine;

public class SpiderMirrorEvent : ScareEvent
{
    public SpiderMirrorEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Spider Mirror Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        result.Add(ScareType.DISGUST,50);
        //todo animate event
        return result;
    }
}
