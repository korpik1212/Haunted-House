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

    public List<RoutineEvent> routine;
    
    private Room currentRoom;
    public Room startingRoom;
    
    Dictionary<Fear, int> fearLevelCaps = new Dictionary<Fear, int>();
    Dictionary<Fear, int> currentFearLevels = new Dictionary<Fear, int>();


    public void Start()
    {
        moveToRoom(startingRoom);
    }
    

    public void DoSimulationStep()
    {
        
        checkFears();

    }

    private void checkFears()
    {
        foreach (Fear fear in fearLevelCaps.Keys)
        {
            if (currentFearLevels[fear] > fearLevelCaps[fear])
            {
                Debug.Log("I,  + name + , have reached my " + fear + " fear level cap and am now incapacitated");
            }
        }
    }
    

    public void moveToRoom(Room room)
    {
        foreach (RoomConnection roomConnection in currentRoom.Pathways)
        {
            if (roomConnection.goesToRoom() == room && !roomConnection.IsLocked)
            {
                Debug.Log("Moving from " + currentRoom.name + " to " + room.name);
                transform.position = room.transform.position;
                checkTraps();
                checkFears();
                return;
            }
            
            if (roomConnection.goesToRoom() == room && roomConnection.IsLocked)
            {
                Debug.Log("I, " + name + ", cannot move from " + currentRoom.name + " to " + room.name + " because the door is locked");
                return;
            }
        }
        
        Debug.Log("I can't go to " + room.name + " because it's not connected to " + currentRoom.name + " where I currently am");
        
    }

    public void checkTraps()
    {
            foreach (EnvironmentElement environmentElement in currentRoom.getEnvironmentElements())
            {
                if (environmentElement.hasTrap())
                {
                    environmentElement.GetTrap().spook();
                }
            }
    }

    public Room getCurrentRoom() => currentRoom;
}
