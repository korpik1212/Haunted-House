using System;
using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{

    public ArrayList EnvironmentElements = new ArrayList();



    private void gatherRoomElements()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            EnvironmentElement environmentElement = child.GetComponent<EnvironmentElement>();
            if (environmentElement != null)
            {
                EnvironmentElements.Add(environmentElement);
            }
        }
    }


    private void Start()
    {
        //gatherRoomElements();
    }

    
}
