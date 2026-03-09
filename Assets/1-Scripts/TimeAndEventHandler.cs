using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndEventHandler : MonoBehaviour
{

    public static TimeAndEventHandler instance;
    

    
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
    }

   
    [ContextMenu("Trigger All Events")]
    public void TestTriggerCommand()
    {
        
    }

    public void AssignEvent(ScareCard scareCard, EnvironmentElement host, DateTime startTime)
    {
        if (getEvent(scareCard, host) != null)
        {
            Event eventToAdd = getEvent(scareCard, host);
            if (host.checkTimeSlotAvailability(startTime,eventToAdd.getDuration()))
            {
                eventToAdd.setStartTime(startTime);
                host.addEvent(eventToAdd);
            }
        }
    }

    private Event getEvent(ScareCard sc, EnvironmentElement h)
    {
        Event result = null;
        switch (sc)
        {
            case ScareCard.ENVIORMENTALGHOST :
                switch (h.type)
                {
                    case EnvironmentElementType.COUCH:
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
