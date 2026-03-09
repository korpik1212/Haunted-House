using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
  
    public UnityEvent OnHouseCleared;


    public House startingHousePrefab;
    private void Start()
    {
        SetupHouse();
    }


    public void SetupHouse()
    {

        House h = Instantiate(startingHousePrefab, Vector3.zero, Quaternion.identity);
        //generate a house 
        //generate rooms
        //generate furniture for the room
        //cards for player?

        //wait for a while for animation etc 


        //start allowing player inputs 



    }

    public void HouseCleared()
    {

        OnHouseCleared.Invoke();
    }
}
