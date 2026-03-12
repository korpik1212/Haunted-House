using System.Collections.Generic;
using UnityEngine;

public class SpiderPolsteredSchmevent : ScareSchmevent
{
    public SpiderPolsteredSchmevent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Spider Polstered Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventSpider");
        return result;
    }
}
