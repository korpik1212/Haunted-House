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
                        result = new DecayPolsteredEvent(h);
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        //todo result= new DECAY_BOOKSHELF_EVENT()
                        break;
                    case EnvironmentElementType.DOOR:
                        //todo result= new DECAY_DOOR_EVENT()
                        break;
                    case EnvironmentElementType.FRIDGE:
                        result = new DecayFridgeEvent(h);
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        result = new DecayLightswitchEvent(h);
                        break;
                    case EnvironmentElementType.MIRROR:
                        //todo result= new DECAY_MIRROR_EVENT()
                        break;
                    case EnvironmentElementType.PIPES:
                        result = new DecayPipesEvent(h);
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
                        result = new SpiderPolsteredEvent(h);
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        result = new SpiderBookshelfEvent(h);
                        break;
                    case EnvironmentElementType.DOOR:
                        result = new SpiderDoorEvent(h);
                        break;
                    case EnvironmentElementType.FRIDGE:
                        result = new SpiderFridgeEvent(h);
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        result = new SpiderLightswitchEvent(h);
                        break;
                    case EnvironmentElementType.MIRROR:
                        result = new SpiderMirrorEvent(h);
                        break;
                    case EnvironmentElementType.PIPES:
                        result = new SpiderPipesEvent(h);
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
                        result = new RatBookshelfEvent(h);
                        break;
                    case EnvironmentElementType.DOOR:
                        result = new RatDoorEvent(h);
                        break;
                    case EnvironmentElementType.FRIDGE:
                        //todo result= new RAT_FRIDGE_EVENT()
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        result = new RatLightswitchEvent(h);
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