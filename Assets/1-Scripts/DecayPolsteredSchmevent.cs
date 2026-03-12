using System.Collections.Generic;
using UnityEngine;

public class DecayPolsteredSchmevent : ScareSchmevent
{
    public DecayPolsteredSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("Cards/Decay");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Decay Polstered Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.DISGUST,10);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventDecay");
        // sound
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Decay");
        return result;
    }
}
