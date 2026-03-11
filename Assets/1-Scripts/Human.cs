using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Human : MonoBehaviour
{

    public List<RoutineSchmevent> routine;
    
    private Room currentRoom;
    public Room startingRoom;
    
    public Dictionary<ScareType, int> fearLevelCaps = new Dictionary<ScareType, int>();
    public Dictionary<ScareType, int> currentFearLevels = new Dictionary<ScareType, int>();
    
    public void Start()
    {
        
        currentRoom = startingRoom;
        transform.position = currentRoom.transform.position;

    }

    private void Awake()
    {
        Debug.Log("Awake");
        setupRoutine();
    }
    
    public void setupRoutine()
    {
        Debug.Log("setupRoutine");
        int i = 0;
        foreach (RoutineSchmevent routineEvent in routine)
        {
            i++;
            Debug.Log("Routine called: " + i+ "Routines found: " + routine.Count);    
            routineEvent.SetupRoutineEvent();
        }
        Debug.Log("Routine called: " + i+ "Routines found: " + routine.Count);
    }
    
    private void checkFears()
    {
        foreach (ScareType scareType in fearLevelCaps.Keys)
        {
            if (currentFearLevels[scareType] >= fearLevelCaps[scareType])
            {
                Debug.Log("I, "  + name + ", have reached my " + scareType + " fear level cap and am now incapacitated");
            }
        }
    }

    private void spookReaction(ScareSchmevent t)
    {
                    
        var scaresSuffered = t.spook(this);
        sufferScares(scaresSuffered);
    } 
    
    private void sufferScares(Dictionary<ScareType, int> scaresSuffered)
    {
        foreach (KeyValuePair<ScareType, int> scare in scaresSuffered)
        {
            currentFearLevels[scare.Key] += scare.Value;
            Debug.Log("I, " + name + ", have suffered " + scare.Value + " " + scare.Key + " and am now at " + currentFearLevels[scare.Key] + " " + scare.Key);
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
                currentRoom = room;
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
                    spookReaction(environmentElement.GetTrap());
                }
            }
    }

    public Room getCurrentRoom() => currentRoom;

    public float getFearRatio(ScareType scareType)
    {
        return  (float)currentFearLevels[scareType] / (float)fearLevelCaps[scareType];
    }
}
