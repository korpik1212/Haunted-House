using System.Collections.Generic;
using UnityEngine;

public class SpiderPolsteredEvent : ScareEvent
{
    public SpiderPolsteredEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Spider Polstered Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        //todo animate event
        return result;
    }
}
