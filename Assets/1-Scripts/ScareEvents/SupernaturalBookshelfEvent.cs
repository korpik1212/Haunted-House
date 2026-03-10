using System.Collections.Generic;
using UnityEngine;

public class SupernaturalBookshelfEvent : ScareEvent
{
    public SupernaturalBookshelfEvent(EnvironmentElement h) : base(h)
    {
    }

    public override Dictionary<ScareType, int> spook()
    {
        Debug.Log("Supernatural Bookshelf Event");
        Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
        result.Add(ScareType.PARANOIA,50);
        //todo animate event
        return result;
    }
}
