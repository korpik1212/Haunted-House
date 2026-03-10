using System.Collections.Generic;
using UnityEngine;

public class RoutineScriptableObject : ScriptableObject
{
    //Routines hold a list of routine actions, which are either a movement to a different room, or an interaction with an environment element.
    public List<RoutineAction> RoutineActions;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public RoutineAction getRoutineAction(int index) => RoutineActions[index];
    
}
