using System.Collections.Generic;
using UnityEngine;

public class SpiderPipesSchmevent : ScareSchmevent
{
    public SpiderPipesSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("Cards/Spider");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Spider Pipes Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        result.Add(ScareType.DISGUST,50);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventSpider");
        return result;
    }
}
