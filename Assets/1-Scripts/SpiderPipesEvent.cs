using System.Collections.Generic;
using UnityEngine;

public class SpiderPipesEvent : ScareEvent
{
    public SpiderPipesEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Spider Pipes Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        result.Add(ScareType.DISGUST,50);
        //todo animate event
        return result;
    }
}
