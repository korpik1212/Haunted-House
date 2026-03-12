using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;
using Object = System.Object;

public class PlayerActionsManager : MonoBehaviour
{
    [SerializeField] private LayerMask hitLayer = ~0;

    private Camera mainCamera;
    private IHoverable currentHoverable;

    public Card currentlySelectedCard;


    public static PlayerActionsManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (GameManager.getInstance().IsPlayerInputAllowed == false) return;
        if (Mouse.current == null)
        {
            return;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        GameObject objectUnderMouse = GetTopMostObject(worldPosition);

        UpdateHoverState(objectUnderMouse);
        
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ProcessClick(objectUnderMouse, worldPosition);
        }
        

        if (currentlySelectedCard != null)
        {
            currentlySelectedCard.transform.position = new Vector3(Pointer.current.position.ReadValue().x,Pointer.current.position.ReadValue().y, 0f);
            if (InputSystem.actions["RightClick"].WasPressedThisFrame())
            {
                releaseCard();
            }
        }
    }

    public void SelectCard(Card card)
    {
        currentlySelectedCard = card;
    }

    private GameObject GetTopMostObject(Vector2 worldPosition)
    {
        Collider2D[] hits = Physics2D.OverlapPointAll(worldPosition, hitLayer);

        GameObject bestObject = null;
        SpriteRenderer bestRenderer = null;

        foreach (Collider2D hit in hits)
        {
            SpriteRenderer currentRenderer = hit.GetComponentInParent<SpriteRenderer>();

            if (currentRenderer == null)
            {
                continue;
            }

            if (bestRenderer == null)
            {
                bestObject = hit.gameObject;
                bestRenderer = currentRenderer;
                continue;
            }

            int currentLayerValue = SortingLayer.GetLayerValueFromID(currentRenderer.sortingLayerID);
            int bestLayerValue = SortingLayer.GetLayerValueFromID(bestRenderer.sortingLayerID);

            if (currentLayerValue > bestLayerValue)
            {
                bestObject = hit.gameObject;
                bestRenderer = currentRenderer;
            }
            else if (currentLayerValue == bestLayerValue)
            {
                if (currentRenderer.sortingOrder > bestRenderer.sortingOrder)
                {
                    bestObject = hit.gameObject;
                    bestRenderer = currentRenderer;
                }
            }
        }

        return bestObject;
    }

    private void UpdateHoverState(GameObject objectUnderMouse)
    {
        IHoverable newHoverable = null;

        if (objectUnderMouse != null)
        {
            newHoverable = objectUnderMouse.GetComponentInParent<IHoverable>();
        }

        if (currentHoverable != newHoverable)
        {
            if (currentHoverable != null)
            {
                currentHoverable.OnHoverExit();
            }

            currentHoverable = newHoverable;

            if (currentHoverable != null)
            {
                currentHoverable.OnHoverEnter();
            }
        }
    }

    private void ProcessClick(GameObject clickedObject, Vector2 worldPosition)
    {
        
        if (clickedObject == null)
        {
            return;
        }
        
       Debug.Log("Clicked on: " + clickedObject.name);
        ICardTargetable targetable = clickedObject.GetComponentInParent<ICardTargetable>();
        if (targetable != null && currentlySelectedCard != null)
        {
            
            if (targetable is EnvironmentElement)
            {
                EnvironmentElement environmentElement = targetable as EnvironmentElement;
                
                if (environmentElement.hasTrap() == false)
                {
                    targetable.OnTargetClick(currentlySelectedCard);
                    //check if the trap was successfully set, if so remove the card from the hand
                    if (environmentElement.hasTrap()) {
                        GameManager.getInstance().cardHolder.RemoveCardFromHand(currentlySelectedCard);
                    }
                    
                }
               
                releaseCard();
                
            }
            
        }
    }

   
    public void releaseCard()
    {
        if (currentlySelectedCard != null)
        {
            currentlySelectedCard.transform.SetParent(GameManager.getInstance().cardHolder.transform);
            currentlySelectedCard.isSelected = false;
            currentlySelectedCard = null;
        }
    }
    
}
public interface IHoverable
{
    void OnHoverEnter();
    void OnHoverExit();
}