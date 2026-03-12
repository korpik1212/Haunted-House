using System.Collections.Generic;
using UnityEngine;

public class RatBookshelfSchmevent : ScareSchmevent
{
    public RatBookshelfSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("Cards/Rat");
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
