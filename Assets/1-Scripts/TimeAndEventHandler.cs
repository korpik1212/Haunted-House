using System;
using System.Collections.Generic;
using _1_Scripts.ScareEvents;
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

    public void SetTrap(ScareCard scareCard, EnvironmentElement host)
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
            case ScareCard.SUPERNATURAL :
                switch (h.type)
                {
                    case EnvironmentElementType.POLSTERED:
                        result = new TestEvent(h, sc);
                        Debug.Log("assigned event");
                        //todo result= new SUPERNATURAL_COUCH_EVENT()
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        result = new SupernaturalBookshelfEvent(h);
                        break;
                    case EnvironmentElementType.DOOR:
                        //todo result= new SUPERNATURAL_DOOR_EVENT()
                        break;
                    case EnvironmentElementType.FRIDGE:
                        result = new SupernaturalFridgeEvent(h);
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        //todo result= new SUPERNATURAL_LIGHTSWITCH_EVENT()
                        break;
                    case EnvironmentElementType.MIRROR:
                        result = new SupernaturalMirrorEvent(h);
                        break;
                    case EnvironmentElementType.PIPES:
                        //todo result= new SUPERNATURAL_PIPES_EVENT()
                        break;
                    case EnvironmentElementType.PLUSHY:
                        //todo result= new SUPERNATURAL_PLUSHY_EVENT()
                        break;
                }
                break;
            case ScareCard.DECAY :
                switch (h.type)
                {
                    case EnvironmentElementType.POLSTERED:
                        //todo result= new DECAY_COUCH_EVENT()
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        //todo result= new DECAY_BOOKSHELF_EVENT()
                        break;
                    case EnvironmentElementType.DOOR:
                        //todo result= new DECAY_DOOR_EVENT()
                        break;
                    case EnvironmentElementType.FRIDGE:
                        //todo result= new DECAY_FRIDGE_EVENT()
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        //todo result= new DECAY_LIGHTSWITCH_EVENT()
                        break;
                    case EnvironmentElementType.MIRROR:
                        //todo result= new DECAY_MIRROR_EVENT()
                        break;
                    case EnvironmentElementType.PIPES:
                        //todo result= new DECAY_PIPES_EVENT()
                        break;
                    case EnvironmentElementType.PLUSHY:
                        //todo result= new DECAY_PLUSHY_EVENT()
                        break;
                }
                break;
            case ScareCard.SPIDER :
                switch (h.type)
                {
                    case EnvironmentElementType.POLSTERED:
                        //todo result= new SPIDER_COUCH_EVENT()
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        //todo result= new SPIDER_BOOKSHELF_EVENT()
                        break;
                    case EnvironmentElementType.DOOR:
                        //todo result= new SPIDER_DOOR_EVENT()
                        break;
                    case EnvironmentElementType.FRIDGE:
                        //todo result= new SPIDER_FRIDGE_EVENT()
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        //todo result= new SPIDER_LIGHTSWITCH_EVENT()
                        break;
                    case EnvironmentElementType.MIRROR:
                        //todo result= new SPIDER_MIRROR_EVENT()
                        break;
                    case EnvironmentElementType.PIPES:
                        //todo result= new SPIDER_PIPES_EVENT()
                        break;
                    case EnvironmentElementType.PLUSHY:
                        //todo result= new SPIDER_PLUSHY_EVENT()
                        break;
                }
                break;
            case ScareCard.RAT :
                switch (h.type)
                {
                    case EnvironmentElementType.POLSTERED:
                        //todo result= new RAT_COUCH_EVENT()
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        //todo result= new RAT_BOOKSHELF_EVENT()
                        break;
                    case EnvironmentElementType.DOOR:
                        //todo result= new RAT_DOOR_EVENT()
                        break;
                    case EnvironmentElementType.FRIDGE:
                        //todo result= new RAT_FRIDGE_EVENT()
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        //todo result= new RAT_LIGHTSWITCH_EVENT()
                        break;
                    case EnvironmentElementType.MIRROR:
                        //todo result= new RAT_MIRROR_EVENT()
                        break;
                    case EnvironmentElementType.PIPES:
                        //todo result= new RAT_PIPES_EVENT()
                        break;
                    case EnvironmentElementType.PLUSHY:
                        //todo result= new RAT_SINK_EVENT()
                        break;
                }
                break;
        }
        h.setTrap(result);
        return result;
    }

    public class TestEvent : ScareEvent
    {
        public TestEvent(EnvironmentElement h, ScareCard c) : base(h)
        {

        }

        public override Dictionary<ScareType, int> spook()
        {

            Debug.Log("hello");

            return null;
        }
    }
}