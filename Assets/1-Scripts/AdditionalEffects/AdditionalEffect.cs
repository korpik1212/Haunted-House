using UnityEngine;

[CreateAssetMenu(fileName = "AdditionalEffect", menuName = "ScriptableObjects/AdditionalEffect", order = 1)]

public abstract class AdditionalEffect : ScriptableObject
{
   public abstract void DoEffect(Human human, Room room);
}
