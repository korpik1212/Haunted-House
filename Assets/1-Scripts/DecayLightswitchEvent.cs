using System.Collections.Generic;
using UnityEngine;

public class DecayLightswitchEvent : ScareEvent
{
    public DecayLightswitchEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Decay Lightswitch Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK, 40);
        //todo animate event
        return result;
    }
}
