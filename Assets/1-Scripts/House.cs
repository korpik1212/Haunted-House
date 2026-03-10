using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class House : MonoBehaviour
{
    public List<Card> avaibleCards;
    public List<Room> rooms;
    public List<Human> humans;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rooms = getAllRooms();
        humans = getAllHumans();
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
    
    public void DoSimulationStep()
    {
        foreach (Room room in rooms)
        {
            
            //Simulate the events 
            foreach (EnvironmentElement environmentElement in room.EnvironmentElements)
            {
                environmentElement.DoSimulationStep();
            }
            
            //Simulate the humans' behaviors
            foreach (Human human in humans)
            {
                //Make humans do teh next thing in their routine, or make them decide what to do next based on their fear levels and other factors
            }
        }
    }
}
