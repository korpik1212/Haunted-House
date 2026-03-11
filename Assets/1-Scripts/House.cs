using UnityEngine;
using System.Collections.Generic;


public class House : MonoBehaviour
{
    public List<Card> avaibleCards;
    public List<Room> rooms;
    public List<Human> humans;
    public List<Door> doors;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rooms = getAllRooms();
        humans = getAllHumans();
        TimeAndEventHandler.getInstance().house = this;
        GameManager.getInstance().house = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private List<Room> getAllRooms()
    {
        List<Room> rooms = new List<Room>();
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Room room = child.GetComponent<Room>();
            if (room != null)
            {
                rooms.Add(room);
                room.house = this;
            }
        }
        return rooms;
    }
    
    private List<Human> getAllHumans()
    {
        List<Human> humans = new List<Human>();
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Human human = child.GetComponent<Human>();
            if (human != null)
            {
                humans.Add(human);
            }
        }
        return humans;
    }
}
