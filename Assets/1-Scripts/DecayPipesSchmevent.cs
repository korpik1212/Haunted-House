using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DecayPipesSchmevent : ScareSchmevent
{
    public DecayPipesSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("EffectSprites/event_rat2");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Decay Pipes Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.DISGUST,70);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventDecay");
        // sound
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Decay");
        return result;
    }
}
