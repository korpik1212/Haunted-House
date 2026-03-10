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
            foreach (RoutineSchmevent routineEvent in human.routine)
            {
                if (routineEvent.getStartTime().Equals(currentTime))
                {
                    PerformRoutineEvent(human, routineEvent);
                }
            }
        }
    }

    public void PerformRoutineEvent(Human human, RoutineSchmevent routineSchmevent)
    {
        human.moveToRoom(routineSchmevent.destinationRoom.GetComponent<Room>());
        if (routineSchmevent.additionalEffect != null && human.getCurrentRoom() == routineSchmevent.destinationRoom)
        {
            routineSchmevent.additionalEffect.DoEffect(human, routineSchmevent.destinationRoom.GetComponent<Room>());
        }

    }

    [ContextMenu("Trigger All Events")]
    public void TestTriggerCommand()
    {
        
    }

    public void SetTrap(ScareCard scareCard, EnvironmentElement host)
    {
        if (getScareEvent(scareCard, host) != null)
        {
            ScareSchmevent schmeventToAdd = getScareEvent(scareCard, host);

            if (host.checkTimeSlotAvailability())
            {
                host.setTrap(schmeventToAdd);
            }
        }
    }

    private ScareSchmevent getScareEvent(ScareCard sc, EnvironmentElement h)
    {
        ScareSchmevent result = null;
        switch (sc)
        {
            case ScareCard.SUPERNATURAL :
                switch (h.type)
                {
                    case EnvironmentElementType.POLSTERED:
                        result = new TestSchmevent(h, sc);
                        Debug.Log("assigned event");
                        //todo result= new SUPERNATURAL_COUCH_EVENT()
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        result = new SupernaturalBookshelfSchmevent(h);
                        break;
                    case EnvironmentElementType.DOOR:
                        //todo result= new SUPERNATURAL_DOOR_EVENT()
                        break;
                    case EnvironmentElementType.FRIDGE:
                        result = new SupernaturalFridgeSchmevent(h);
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        //todo result= new SUPERNATURAL_LIGHTSWITCH_EVENT()
                        break;
                    case EnvironmentElementType.MIRROR:
                        result = new SupernaturalMirrorSchmevent(h);
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
                        result = new DecayPolsteredSchmevent(h);
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        //todo result= new DECAY_BOOKSHELF_EVENT()
                        break;
                    case EnvironmentElementType.DOOR:
                        //todo result= new DECAY_DOOR_EVENT()
                        break;
                    case EnvironmentElementType.FRIDGE:
                        result = new DecayFridgeSchmevent(h);
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        result = new DecayLightswitchSchmevent(h);
                        break;
                    case EnvironmentElementType.MIRROR:
                        //todo result= new DECAY_MIRROR_EVENT()
                        break;
                    case EnvironmentElementType.PIPES:
                        result = new DecayPipesSchmevent(h);
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
                        result = new SpiderPolsteredSchmevent(h);
                        break;
                    case EnvironmentElementType.BOOKSHELF:
                        result = new SpiderBookshelfSchmevent(h);
                        break;
                    case EnvironmentElementType.DOOR:
                        result = new SpiderDoorSchmevent(h);
                        break;
                    case EnvironmentElementType.FRIDGE:
                        result = new SpiderFridgeSchmevent(h);
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        result = new SpiderLightswitchSchmevent(h);
                        break;
                    case EnvironmentElementType.MIRROR:
                        result = new SpiderMirrorSchmevent(h);
                        break;
                    case EnvironmentElementType.PIPES:
                        result = new SpiderPipesSchmevent(h);
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
                        result = new RatBookshelfSchmevent(h);
                        break;
                    case EnvironmentElementType.DOOR:
                        result = new RatDoorSchmevent(h);
                        break;
                    case EnvironmentElementType.FRIDGE:
                        //todo result= new RAT_FRIDGE_EVENT()
                        break;
                    case EnvironmentElementType.LIGHTSWITCH:
                        result = new RatLightswitchSchmevent(h);
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

    public class TestSchmevent : ScareSchmevent
    {
        public TestSchmevent(EnvironmentElement h, ScareCard c) : base(h)
        {

        }

        public override Dictionary<ScareType, int> spook(Human human)
        {

            Debug.Log("hello");

            return null;
        }
    }
}