using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DecayPipesEvent : ScareEvent
{
    public DecayPipesEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Decay Pipes Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.DISGUST,70);
        //todo animate event
        return result;
    }
}
