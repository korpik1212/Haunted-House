using System.Collections.Generic;
using UnityEngine;

public class DecayFridgeSchmevent : ScareSchmevent
{
    public DecayFridgeSchmevent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Decay Fridge Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.DISGUST,50);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventDecay");
        // sound
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Decay");
        return result;
    }
}
