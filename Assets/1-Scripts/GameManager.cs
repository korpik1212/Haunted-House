using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class GameManager 
{
  
    public UnityEvent OnHouseCleared;
    public House startingHousePrefab;


    private static GameManager instance;

    public CardHolder cardHolder;

    public bool IsPlayerInputAllowed;

    private void Awake()
    {
        
    }

    public static GameManager getInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }
        
        return instance;

    }
    



    House createdHouse;
    public void SetupHouse()
    {

        createdHouse = Instantiate(startingHousePrefab, Vector3.zero, Quaternion.identity);
        //generate a house 
        //generate rooms
        //generate furniture for the room
        //cards for player?

        //wait for a while for animation etc 


        //start allowing player inputs 



    }
    public void SetupCards()
    {
        foreach(Card cardPrefab in createdHouse.avaibleCards)
        {
           Card card= Instantiate(cardPrefab, Vector3.zero, Quaternion.identity,cardHolder.transform);
            cardHolder.cards.Add(card);
        }
    }

    public IEnumerator GameLoop()
    {

        SetupHouse();
        yield return new WaitForSeconds(1);

        SetupCards();

        yield return new WaitForSeconds(5);

        IsPlayerInputAllowed = true;


        yield return new WaitForSeconds(30);
        IsPlayerInputAllowed = false;
    }

    public void HouseCleared()
    {

        OnHouseCleared.Invoke();
    }
}
