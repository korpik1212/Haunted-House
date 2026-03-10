using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugEffect", menuName = "ScriptableObjects/DebugEffect", order = 10)]

public class DebugEffect : AdditionalEffect
{
    
    public String DebugMessage = "DebugEffect applied!";

    public override void DoEffect(Human human, Room room)
    {
        Debug.Log(DebugMessage);
    }
}
