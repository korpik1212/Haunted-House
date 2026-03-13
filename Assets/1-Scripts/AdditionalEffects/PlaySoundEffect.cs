using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugEffect", menuName = "ScriptableObjects/PlaySoundEffect", order = 10)]

public class PlaySoundEffect : AdditionalEffect
{
    
    public String SoundEffectName = "Mum_Sounds_Talk";

    public override void DoEffect(Human human, Room room)
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().Play(SoundEffectName);
    }
}
