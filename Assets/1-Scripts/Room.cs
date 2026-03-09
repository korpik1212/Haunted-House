using UnityEngine;

public class Room : MonoBehaviour, ICardTargetable,IHoverable
{

    public EnvironmentElement environmentElement;



    public void AssignEnviormentElement(EnvironmentElement environmentElement)
    {

    }



    public void OnTargetClick(Card card)
    {
        Debug.Log("got target clicked");
        TimeAndEventHandler.instance.GenerateEvent(card.CardType, environmentElement);
    }

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
}
