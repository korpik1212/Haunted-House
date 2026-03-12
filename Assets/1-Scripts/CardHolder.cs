using System;
using UnityEngine;
using System.Collections.Generic;

public class CardHolder : MonoBehaviour
{
    public List<Card> cards = new List<Card>();


    public void Start()
    {
        GameManager.getInstance().cardHolder = this;
        SetupCards();
    }
    
    public void SetupCards()
    {
        foreach(Card cardPrefab in GameManager.getInstance().house.avaibleCards)
        {
            Card card = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity,transform);
            cards.Add(card);
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


    public float spacing = 150f;
    public float maxRotation = 15f;
    public float heightArc = 20f;
    public float lerpSpeed = 12f;

    private void Update()
    {
        UpdateCardPositions();
    }

    public void UpdateCardPositions()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            float normalizedPos = (cards.Count > 1) ? (i / (float)(cards.Count - 1)) * 2f - 1f : 0f;

            float xPos = (i - (cards.Count - 1) / 2f) * spacing;
            float yPos = -Mathf.Abs(normalizedPos) * heightArc;
            float zRot = -normalizedPos * maxRotation;

            Vector3 targetPos = new Vector3(xPos, yPos, 0f);
            Quaternion targetRot = Quaternion.Euler(0f, 0f, zRot);
            //move to start to get the starting size from there 
            Vector3 targetScale = new Vector3(1.1625f, 1.75f, 1f);

            bool isHovered = cards[i].isHovering;

            if (isHovered)
            {
                targetPos.y += 50f;
                targetRot = Quaternion.identity;
                targetScale = targetScale * 1.2f;
                cards[i].transform.SetAsLastSibling();
            }
            else
            {
                cards[i].transform.SetSiblingIndex(i);
            }

            cards[i].transform.localPosition = Vector3.Lerp(cards[i].transform.localPosition, targetPos, Time.deltaTime * lerpSpeed);
            cards[i].transform.localRotation = Quaternion.Lerp(cards[i].transform.localRotation, targetRot, Time.deltaTime * lerpSpeed);
            cards[i].transform.localScale = Vector3.Lerp(cards[i].transform.localScale, targetScale, Time.deltaTime * lerpSpeed);
        }
    }


}
