using UnityEngine;
using System.Collections.Generic;

public class CardHolder : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public static CardHolder instance;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }



    public void RemoveCardFromHand(Card card)
    {

        if (cards.Contains(card))
        {
            cards.Remove(card);
        }
        Destroy(card.gameObject);
    }


    private void Update()
    {
        UpdateCardPositions();
        UpdateCardRotations();
    }



    public void UpdateCardPositions()
    {

        float spacing = 150f;

        for (int i = 0; i < cards.Count; i++)
        {
            float xPos = (i - (cards.Count - 1) / 2f) * spacing;
            cards[i].transform.localPosition = new Vector3(xPos, 0f, 0f);
        }

    }

    public void UpdateCardRotations()
    {

    }



}
