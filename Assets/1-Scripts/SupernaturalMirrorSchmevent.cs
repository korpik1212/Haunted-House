using System.Collections.Generic;
using UnityEngine;

public class SupernaturalMirrorSchmevent : ScareSchmevent
{
    public SupernaturalMirrorSchmevent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Supernatural Mirror Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.PARANOIA,60);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventSuper");
        // sound
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Supernatrual");
        return result;
    }
}
