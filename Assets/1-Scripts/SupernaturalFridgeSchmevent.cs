using System.Collections.Generic;
using UnityEngine;

namespace _1_Scripts.ScareEvents
{
    public class SupernaturalFridgeSchmevent : ScareSchmevent
    {
        public SupernaturalFridgeSchmevent(EnvironmentElement h) : base(h)
        {
            eventSprite = Resources.Load<Sprite>("EffectSprites/event_hallu");
        }

        public override Dictionary<ScareType, int> spook(Human human)
        {
            Debug.Log("Supernatural Fridge Event triggered");
            Dictionary<ScareType, int> result= new Dictionary<ScareType, int>();
            result.Add(ScareType.PARANOIA,30);
            result.Add(ScareType.DISGUST,50);
            // animate event
            getHost().gameObject.transform.GetComponent<Animator>().SetTrigger("eventSuper");
            // sound
            GameObject.Find("SoundManager").GetComponent<SoundManager>().Play("Card_Sounds_Supernatrual");
            return result;
        }
    }
}