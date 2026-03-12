using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum EnvironmentElementType
{
    PIPES,
    BOOKSHELF,
    LIGHTSWITCH,
    POLSTERED,
    FRIDGE,
    MIRROR,
    DOOR,
    PLUSHY
}

[System.Serializable]
public class EnvironmentElement : MonoBehaviour,ICardTargetable,IHoverable
{
    // Environment Element
    // * Events<>
    // * functionality to check time availability and other shit()

    private ScareSchmevent Trap = null;

    public EnvironmentElementType type;
    

    public void setTrap(ScareSchmevent e)
    {
        Trap = e;
    }

    public bool hasTrap()
    {
        return Trap != null;
    }

    public ScareSchmevent GetTrap()
    {
        return Trap;
    }


    public bool canAcceptThisTrap(ScareCard trapType)
    {
        return true;
    }

    public void OnTargetHoverEnter(Card card)
    {

    }

    public void OnHoverEnter()
    {
        // Debug.Log("hovering");
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
        TimeAndEventHandler.getInstance().SetTrap(card.CardType, this);
    }
}

