using System;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameStateManager : MonoBehaviour
{
    public int maxNights;
    public List<Func<bool>> winConditions = new List<Func<bool>>();
    private int currentNight;
    public UnityEvent win;
    public UnityEvent lose;
    
    public void Start()
    {
        Debug.Log("Starting GameStateManager");
        GameManager.getInstance().gameStateManager = this;
    }
    public void Update()
    {
        currentNight = (TimeAndEventHandler.getInstance().currentTime - new DateTime(2026, 01, 01)).Days;
    }
    
    public void updateGameState()
    {
        if (currentNight >= maxNights)
        {
            lose.Invoke();
        } else if (winConditionsFulfilled())
        {
            win.Invoke();
        }
    }
    
    public abstract bool winConditionsFulfilled();
}
