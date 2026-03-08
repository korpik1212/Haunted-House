using UnityEngine;

public class Room : MonoBehaviour, ICardTargetable,IHoverable
{



    public void OnTargetClick(Card card)
    {
        Debug.Log("got target clicked");
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
