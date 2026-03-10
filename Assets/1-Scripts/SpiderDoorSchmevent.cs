using System.Collections.Generic;
using UnityEngine;

public class SpiderDoorSchmevent : ScareSchmevent
{
    public SpiderDoorSchmevent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Spider Door Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        //todo animate event
        return result;
    }
}
