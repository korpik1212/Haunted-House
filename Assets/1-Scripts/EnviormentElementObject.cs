using UnityEngine;
using System;

public class EnviormentElementObject : MonoBehaviour, ICardTargetable, IHoverable
{
   public EnvironmentElement environmentElement;




    public void OnTargetHoverEnter(Card card)
    {

    }

    public void OnHoverEnter()
    {
        Debug.Log("hoverinn");
    }

    public void OnTargetHoverExit(Card card)
    {
    }

    public void OnHoverExit()
    {
    }

    public void OnTargetClick(Card card)
    {
        Debug.Log(card.CardType.ToString());
        Debug.Log(gameObject.name);
        TimeAndEventHandler.instance.AssignEvent(card.CardType, environmentElement, startTime: DateTime.Now);
    }
}
