using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum Fear
{
    Disgust,
    Shock,
    Paranoia
}

public class Human : MonoBehaviour
{

    public Room currentRoom;
    public Room startingRoom;
    
    Dictionary<Fear, int> fearLevelCaps = new Dictionary<Fear, int>();
    Dictionary<Fear, int> currentFearLevels = new Dictionary<Fear, int>();


    public void Start()
    {
        currentRoom = startingRoom;
    }

    public void MoveToRoom(Room room)
    {
        //move anim 

        //event trigger 
        // if there is a card that triggers when human enters room it triggers now 
    }

    public void DoSimulationStep()
    {

        foreach (Fear fear in fearLevelCaps.Keys)
        {
            if (currentFearLevels[fear] > fearLevelCaps[fear])
            {
                Debug.Log("I,  + name + , have reached my " + fear + " fear level cap and am now incapacitated");
            }
        }

    }
}
