using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{



    /// <summary   
    ///  1. when players hover over this this should get bigger 
    /// 2. there should be a general card holder that gives cards their positions (if I hover over one card the other cards should probably be pushed)
    /// 3- when I drag a card it shoudl first get bigger for hover, then it should start targeting (slay the spire target thing )
    /// 4- when hovering over a Itargetable object,  trigger hover for it and make this appliable (apply the effect of the card? create an event with spesific stats
    ///  5- when stop draggin while hovering over a Itargetable object apply the click effect of IcardTargetable
    /// 6- if I stop dragging without 
    /// 
    /// different targetables and target systems (always target rooms, so only rooms have targetable 
    /// >   



    public Vector3 startingSize;
    private void Awake()
    {
        startingSize = transform.localScale;
    }


    public void OnSelected()
    {

    }

  
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(startingSize * 1.2f, 0.2f);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(startingSize, 0.2f);

    }
}
