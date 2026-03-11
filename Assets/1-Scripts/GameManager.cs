using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class GameManager 
{
    private static GameManager instance;

    public CardHolder cardHolder;
    public House house;
    public GameStateManager gameStateManager;
    
    public bool IsPlayerInputAllowed = true;
    

    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        
        return instance;

    }

    public void Start()
    {
        Debug.Log("Start");
        IsPlayerInputAllowed = true;
    }
    
}
