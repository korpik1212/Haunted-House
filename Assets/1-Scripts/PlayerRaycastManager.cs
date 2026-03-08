using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;

public class PlayerRaycastManager : MonoBehaviour
{
    [SerializeField] private LayerMask hitLayer = ~0;

    private Camera mainCamera;
    private IHoverable currentHoverable;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Mouse.current == null)
        {
            return;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        GameObject objectUnderMouse = GetTopMostObject(worldPosition);

        UpdateHoverState(objectUnderMouse);

        if (Mouse.current.leftButton.wasPressedThisFrame && objectUnderMouse != null)
        {
            ProcessClick(objectUnderMouse, worldPosition);
        }
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
       
    }

   
}
public interface IHoverable
{
    void OnHoverEnter();
    void OnHoverExit();
}