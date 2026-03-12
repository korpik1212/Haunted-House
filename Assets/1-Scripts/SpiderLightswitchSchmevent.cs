using System.Collections.Generic;
using UnityEngine;

public class SpiderLightswitchSchmevent : ScareSchmevent
{
    public SpiderLightswitchSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("EffectSprites/event_spider");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Spider Lightswitch Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventSpider");
        // sound
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Spiders");
        return result;
    }
}
