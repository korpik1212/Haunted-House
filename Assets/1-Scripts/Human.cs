    using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Human : MonoBehaviour
{

    public List<RoutineSchmevent> routine;
    public List<HumanFearValue> fearValues;

    private Room currentRoom;
    public Room startingRoom;
    public TMPro.TextMeshProUGUI bubol;
    public Dictionary<ScareType, int> fearLevelCaps = new Dictionary<ScareType, int>();
    public Dictionary<ScareType, int> currentFearLevels = new Dictionary<ScareType, int>();
    private static int DEFAULT_FEAR_LEVEL_CAP = 100;
    public String veryScaredSound;
    public String slightlyScaredSound;
    public String notScaredSound;
    
    public void Start()
    {
        
        currentRoom = startingRoom;
        transform.position = currentRoom.PersonAnchor.transform.position;
        setupFearCaps();

    }

    private void Awake()
    {
        //Debug.Log("Awake");
        setupRoutine();
    }

    public void setupFearCaps()
    {
        
        foreach (ScareType scareType in Enum.GetValues(typeof(ScareType)))
        {
            currentFearLevels.TryAdd(scareType, 0);
            foreach (HumanFearValue humanFearValue in fearValues)
            {
                if (humanFearValue.scareType == scareType)
                {
                    fearLevelCaps.TryAdd(scareType, humanFearValue.cap);
                }
            }
            fearLevelCaps.TryAdd(scareType, DEFAULT_FEAR_LEVEL_CAP);
        }
    }

    public void setupRoutine()
    {
        //Debug.Log("setupRoutine");
        int i = 0;
        foreach (RoutineSchmevent routineEvent in routine)
        {
            i++;
           // Debug.Log("Routine called: " + i+ "Routines found: " + routine.Count);    
            routineEvent.SetupRoutineEvent();
        }
        //Debug.Log("Routine called: " + i+ "Routines found: " + routine.Count);
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
            if (currentFearLevels.ContainsKey(scare.Key))
            {
                currentFearLevels[scare.Key] += scare.Value;
                if (fearLevelCaps[scare.Key]/scare.Value >= 0.7)
                {
                    bubol.text = GameObject.Find("TalkingHat").GetComponent<TalkingHat>().getVeryScaredQuote(this);
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().Play(veryScaredSound);
                } else if (fearLevelCaps[scare.Key] / scare.Value >= 0.4)
                {
                    bubol.text = GameObject.Find("TalkingHat").GetComponent<TalkingHat>().getScaredQuote(this);
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().Play(slightlyScaredSound);
                }
                else
                {
                    bubol.text = GameObject.Find("TalkingHat").GetComponent<TalkingHat>().getNotScaredQuote(this);
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().Play(notScaredSound);
                }
                Debug.Log("I, " + name + ", have suffered " + scare.Value + " " + scare.Key + " and am now at " + currentFearLevels[scare.Key] + " " + scare.Key);
            }
            
        }
    }
    
    

    public void moveToRoom(Room room)
    {
        foreach (Door door in currentRoom.doors)
        {
            if (!door.isLocked && (door.roomA == room || door.roomB == room))
            {
                Debug.Log("Moving from " + currentRoom.name + " to " + room.name);
                transform.position = room.PersonAnchor.transform.position;
                currentRoom = room;
                checkTraps();
                checkFears();
                return;
            }
            
            if ((door.roomA == room || door.roomB == room) && door.isLocked)
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

    public void HardSetCurrentRoom(Room room)
    {
        currentRoom = room;
        transform.position = room.PersonAnchor.transform.position;
    }
    
    public void ResetToStartingRoom()
    {
        HardSetCurrentRoom(startingRoom);
    }

    public float getFearRatio(ScareType scareType)
    {
        if (!currentFearLevels.ContainsKey(scareType) || !fearLevelCaps.ContainsKey(scareType))
        {
            return 0f;
        }
        return  (float)currentFearLevels[scareType] / (float)fearLevelCaps[scareType];
    }
}
