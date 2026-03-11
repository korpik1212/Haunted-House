using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoLevelManager : GameStateManager
{
    public Human dad;
    private void Awake()
    {
        win.AddListener(doWin);
        lose.AddListener(doLose);
        winConditions.Add(dadIsScared());   
    }

    private void doWin()
    {
        SceneManager.LoadScene("2-Scenes/BuildScenes/WinScreen");
    }

    private void doLose()
    {
        SceneManager.LoadScene("2-Scenes/BuildScenes/LoseScreen");
    }
    
    #region demolevel win condition functions

    private bool dadIsScared()
    {
        if (dad.getFearRatio(ScareType.DISGUST) > 1.0)
        {
            return true;
        }
        else return false;
    }
    
    #endregion
    
    public override bool winConditionsFulfilled()
    {
        foreach (bool b in winConditions)
        {
            if (b) return true;
        }
        return false;
    }
}
