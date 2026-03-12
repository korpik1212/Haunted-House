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
        winConditions.Add(dadIsScared);
        Debug.Log(winConditions.Count);
    }

    private void doWin()
    {
        SceneManager.LoadSceneAsync("2-Scenes/BuildScenes/WinScreen");
    }

    private void doLose()
    {
        SceneManager.LoadSceneAsync("2-Scenes/BuildScenes/LoseScreen");
    }
    
    #region demolevel win condition functions

    private bool dadIsScared()
    {
        if ( dad.getFearRatio(ScareType.SHOCK) > 0.0 || dad.getFearRatio(ScareType.PARANOIA) > 0.0 || dad.getFearRatio(ScareType.DISGUST) > 0.0)
        {
            return true;
        }
        else return false;
    }
    
    #endregion
    
    public override bool winConditionsFulfilled()
    {
        foreach (Func<bool> b in winConditions)
        {
            return b.Invoke();
        }
        return false;
    }
}
