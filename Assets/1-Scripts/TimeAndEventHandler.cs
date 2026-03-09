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

    public void GenerateEvent(ScareCard scareCard, EnvironmentElement environmentElement)
    {
        
    }
}
