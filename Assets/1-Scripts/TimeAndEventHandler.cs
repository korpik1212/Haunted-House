using System.Collections.Generic;
using UnityEngine;

public class TimeAndEventHandler : MonoBehaviour
{

    public static TimeAndEventHandler instance;
    

    private List<EventParent> eventDataBase;
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
        populateDatabase();
    }

    private void populateDatabase()
    {
        eventDataBase = new List<EventParent>();
        //todo append singleton for each event
    }
    [ContextMenu("Trigger All Events")]
    public void TestTriggerCommand()
    {
        
    }

    public void AssignEvent(ScareCard scareCard, EnvironmentElement environmentElement)
    {
        if (doesEventExist(scareCard, environmentElement) != null)
        {
            environmentElement.addEvent(doesEventExist(scareCard, environmentElement));
        }
    }

    private EventParent doesEventExist(ScareCard sc, EnvironmentElement h)
    {
        EventParent result = null;
        foreach(EventParent e in eventDataBase)
        {
            if (e.getCard() == sc && e.getHost() == h)
            {
                result = e;
            }
        }
        return result;
    }
}
