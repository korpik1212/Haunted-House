using System.Collections.Generic;
using UnityEngine;

public class SpiderDoorSchmevent : ScareSchmevent
{
    public SpiderDoorSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("Cards/Spider");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Spider Door Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventSpider");
        // sound
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Spiders");
        return result;
    }
}
