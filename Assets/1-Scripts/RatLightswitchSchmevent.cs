using System.Collections.Generic;
using UnityEngine;

public class RatLightswitchSchmevent : ScareSchmevent
{
    public RatLightswitchSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("EffectSprites/event_rat2");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Rat Bookshelf Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,10);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventRat");
        // sound
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Rat");
        return result;
    }
}
