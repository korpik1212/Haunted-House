using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public CardScriptableObject[] cardDatas;


    
    public static CardFactory instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public CardScriptableObject GetCardData(Card card)
    {

        CardScriptableObject scriptableObject = cardDatas[(int)card.CardType];
        return scriptableObject;
        
    }
}
