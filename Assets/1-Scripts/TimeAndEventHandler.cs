using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndEventHandler : MonoBehaviour
{

    public static TimeAndEventHandler instance;
    public DateTime currentTime;
    public TimeSpan increment = TimeSpan.FromHours(1);
    public House house;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        currentTime = new DateTime(2026, 1, 1, 0, 0, 0);
    }

    public void Update()
    {
        //currentTime += increment*Time.deltaTime;
    }

    public void advanceTime()
    {
        currentTime += increment;
        
    }

    public void doRoutines()
    {
        foreach (Human human in house.humans)
        {
            foreach (RoutineEvent routineEvent in human.routine)
            {
                if (routineEvent.getStartTime().Equals(currentTime))
                {
                    PerformRoutineEvent(human, routineEvent);
                }
            }
        }
    }

    public void PerformRoutineEvent(Human human, RoutineEvent routineEvent)
    {
        human.moveToRoom(routineEvent.destinationRoom.GetComponent<Room>());
        routineEvent.DoAdditionalEffect(routineEvent.destinationRoom.GetComponent<Room>(), human);
    }

    [ContextMenu("Trigger All Events")]
    public void TestTriggerCommand()
    {
        
    }

    public void AssignEvent(ScareCard scareCard, EnvironmentElement host, DateTime startTime)
    {
        if (getScareEvent(scareCard, host) != null)
        {

            ScareEvent eventToAdd = getScareEvent(scareCard, host);

            if (host.checkTimeSlotAvailability())
            {
                host.setTrap(eventToAdd);
            }
        }
    }

    private ScareEvent getScareEvent(ScareCard sc, EnvironmentElement h)
    {
        ScareEvent result = null;
        switch (sc)
        {
            case ScareCard.ENVIORMENTALGHOST :
                switch (h.type)
                {
                    case EnvironmentElementType.COUCH:
                        result = new TestEvent(h, sc);
                        Debug.Log("assigned event");
                        //todo result= new ENVIRONMENTALGHOST_COUCH_EVENT()
                        break;
                    case EnvironmentElementType.MIRROR:
                        //todo result= new ENVIRONMENTALGHOST_MIRROR_EVENT()
                        break;
                    case EnvironmentElementType.SINK:
                        //todo result= new ENVIRONMENTALGHOST_SINK_EVENT()
                        break;
                }
                break;
            case ScareCard.POLTERGEIST :
                switch (h.type)
                {
                    case EnvironmentElementType.COUCH:
                        //todo result= new POLTERGEIST_COUCH_EVENT()
                        break;
                    case EnvironmentElementType.MIRROR:
                        //todo result= new POLTERGEIST_MIRROR_EVENT()
                        break;
                    case EnvironmentElementType.SINK:
                        //todo result= new POLTERGEIST_SINK_EVENT()
                        break;
                }
                break;
            case ScareCard.SPIDER :
                switch (h.type)
                {
                    case EnvironmentElementType.COUCH:
                        //todo result= new SPIDER_COUCH_EVENT()
                        break;
                    case EnvironmentElementType.MIRROR:
                        //todo result= new SPIDER_MIRROR_EVENT()
                        break;
                    case EnvironmentElementType.SINK:
                        //todo result= new SPIDER_SINK_EVENT()
                        break;
                }
                break;
        }
        return result;
    }
}

public class TestEvent : ScareEvent
{
    public TestEvent(EnvironmentElement h, ScareCard c) : base(h, c)
    {

    }
    public override Dictionary<ScareType, int> spook()
    {

        Debug.Log("helooo");

        return null;
    }
}