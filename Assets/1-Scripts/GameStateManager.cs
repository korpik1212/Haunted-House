using System;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameStateManager : MonoBehaviour
{
    public int maxNights;
    public List<bool> winConditions;
    private int currentNight;
    public UnityEvent win;
    public UnityEvent lose;
    public void Update()
    {
        currentNight = (TimeAndEventHandler.getInstance().currentTime - new DateTime(2026, 01, 01)).Days;
        if (currentNight > maxNights)
        {
            lose.Invoke();
        } else if (winConditionsFulfilled())
        {
            win.Invoke();
        }
    }
    
    public abstract bool winConditionsFulfilled();
}
