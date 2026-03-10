using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class Room : MonoBehaviour
{

    private List<EnvironmentElement> EnvironmentElements = new List<EnvironmentElement>();
    public List<RoomConnection> Pathways;


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
        foreach (RoomConnection roomConnection in Pathways)
        {
            if (roomConnection.goesToRoom() == room)
            {
                roomConnection.IsLocked = true;
                Debug.Log("Locked connection from " + name + " to " + room.name);
            }
        }
        
    }

    
}
