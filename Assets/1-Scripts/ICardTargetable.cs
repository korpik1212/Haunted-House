using UnityEngine;

public interface ICardTargetable 
{



    public void OnTargetHoverEnter(Card card);
    public void OnTargetHoverExit(Card card);

    public void OnTargetClick(Card card);



}
