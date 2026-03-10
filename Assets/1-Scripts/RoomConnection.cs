using System;
using UnityEngine;

public class RoomConnection
{

    public bool IsLocked = false;
    public GameObject goesToRoomObject;

    public Room goesToRoom()
    {
     if (goesToRoomObject != null)
     {
         Room room = goesToRoomObject.GetComponent<Room>();
         if (room != null)
         {
             return room;
         }
     }
     Debug.LogError("The goesToRoomObject does not have a Room component attached.");
     return null; 
    }
    
}
