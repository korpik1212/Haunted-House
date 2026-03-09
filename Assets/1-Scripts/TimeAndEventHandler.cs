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

    public void AssignEvent(ScareCard scareCard, EnvironmentElement environmentElement)
    {
        if (getEvent(scareCard, environmentElement) != null)
        {
            environmentElement.addEvent(getEvent(scareCard, environmentElement));
        }
    }

    private EventParent getEvent(ScareCard sc, EnvironmentElement h)
    {
        EventParent result = null;
        
        return result;
    }
}
