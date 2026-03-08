using UnityEngine;



[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/CardScriptableObject", order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public Sprite sprite;
    
    public string cardName;
    public string cardDescription;
}
