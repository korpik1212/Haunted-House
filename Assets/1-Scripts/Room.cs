using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class Room : MonoBehaviour
{

    private List<EnvironmentElement> EnvironmentElements = new List<EnvironmentElement>();
    public List<Door> doors = new List<Door>();
    public House house;

    public List<EnvironmentElement> getEnvironmentElements()
    {
        return EnvironmentElements;
    }

    private void gatherRoomElements()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            EnvironmentElement environmentElement = child.GetComponent<EnvironmentElement>();
            if (environmentElement != null)
            {
                EnvironmentElements.Add(environmentElement);
            }
        }
    }


    private void Start()
    {
        gatherRoomElements();
    }

    public void LockConnectionTo(Room room)
    {
        foreach (Door door in doors)
        {
            if (door.roomA == room || door.roomB == room)
            {
                door.isLocked = true;
                Debug.Log("Locked connection from " + name + " to " + room.name);
            }
        }
        
    }

    
}
