using System.Collections.Generic;
using UnityEngine;

public class DecayLightswitchSchmevent : ScareSchmevent
{
    public DecayLightswitchSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("Cards/Decay");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Decay Lightswitch Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK, 40);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventDecay");
        return result;
    }
}
