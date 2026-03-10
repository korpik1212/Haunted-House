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

    public List<RoutineSchmevent> routine;
    
    private Room currentRoom;
    public Room startingRoom;
    
    Dictionary<Fear, int> fearLevelCaps = new Dictionary<Fear, int>();
    Dictionary<Fear, int> currentFearLevels = new Dictionary<Fear, int>();
    
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
        foreach (Fear fear in fearLevelCaps.Keys)
        {
            if (currentFearLevels[fear] >= fearLevelCaps[fear])
            {
                Debug.Log("I, "  + name + ", have reached my " + fear + " fear level cap and am now incapacitated");
            }
        }
    }

    private void spookReaction(ScareSchmevent t)
    {
                    
        var scaresSuffered = t.spook(this);
        foreach (KeyValuePair<ScareType, int> scare in scaresSuffered)
        {
            switch (scare.Key)
            {
                case ScareType.DISGUST:
                    currentFearLevels[Fear.Disgust] += scare.Value;
                    break;
                case ScareType.PARANOIA:
                    currentFearLevels[Fear.Paranoia] += scare.Value;
                    break;
                case ScareType.SHOCK:
                    currentFearLevels[Fear.Shock] += scare.Value;
                    break;
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
}
