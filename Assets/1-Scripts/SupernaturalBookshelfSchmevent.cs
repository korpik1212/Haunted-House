using System.Collections.Generic;
using UnityEngine;

public class SupernaturalBookshelfSchmevent : ScareSchmevent
{
    public SupernaturalBookshelfSchmevent(EnvironmentElement h) : base(h)
    {
        eventSprite = Resources.Load<Sprite>("Cards/Supernatural");
    }

    public override Dictionary<ScareType, int> spook(Human human)
    {
        Debug.Log("Supernatural Bookshelf Event triggered");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.PARANOIA,50);
        // animate event
        getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventSuper");
        return result;
    }
}
