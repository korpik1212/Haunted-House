using UnityEngine;
using System.Collections.Generic;

public class CardHolder : MonoBehaviour
{
    public List<Card> cards = new List<Card>();



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
