using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DecayPipesSchmevent : ScareSchmevent
{
    public DecayPipesSchmevent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Decay Pipes Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.DISGUST,70);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventDecay");
        return result;
    }
}
