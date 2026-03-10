using System.Collections.Generic;
using UnityEngine;

public class DecayFridgeEvent : ScareEvent
{
    public DecayFridgeEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Decay Fridge Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.DISGUST,50);
        //todo animate event
        return result;
    }
}
