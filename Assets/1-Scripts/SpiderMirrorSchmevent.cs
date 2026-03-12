using System.Collections.Generic;
using UnityEngine;

public class SpiderMirrorSchmevent : ScareSchmevent
{
    public SpiderMirrorSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("Cards/Spider");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Spider Mirror Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.SHOCK,20);
        result.Add(ScareType.DISGUST,50);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventSpider");
        // sound
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Spiders");
        return result;
    }
}
