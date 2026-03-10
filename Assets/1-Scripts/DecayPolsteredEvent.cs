using System.Collections.Generic;
using UnityEngine;

public class DecayPolsteredEvent : ScareEvent
{
    public DecayPolsteredEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Decay Polstered Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.DISGUST,10);
        //todo animate event
        return result;
    }
}
