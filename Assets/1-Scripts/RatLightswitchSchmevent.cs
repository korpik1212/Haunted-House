using System.Collections.Generic;
using UnityEngine;

public class RatLightswitchSchmevent : ScareSchmevent
{
    public RatLightswitchSchmevent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Rat Bookshelf Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,10);
        //todo animate event
        return result;
    }
}
