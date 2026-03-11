using System;
using UnityEngine;

public class DemoLevelManager : GameStateManager
{
    public Human dad;
    private void Awake()
    {
     winConditions.Add(dadIsScared());   
    }

    #region demolevel win condition functions

    private bool dadIsScared()
    {
        if (dad.currentFearLevels[Fear.Disgust] >= dad.fearLevelCaps[Fear.Disgust])
        {
            return true;
        }
        else return false;
    }
    
    #endregion
    
    public override bool winConditionsFulfilled()
    {
        
    }
}
