using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
public class Card : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{



    /// <summary   
    ///  1. when players hover over this this should get bigger 
    /// 2. there should be a general card holder that gives cards their positions (if I hover over one card the other cards should probably be pushed)
    /// 3- when I drag a card it shoudl first get bigger for hover, then it should start targeting (slay the spire target thing )
    /// 4- when hovering over a Itargetable object,  trigger hover for it and make this appliable (apply the effect of the card? create an event with spesific stats
    ///  5- when stop draggin while hovering over a Itargetable object apply the click effect of IcardTargetable
    /// 6- if I stop dragging without 
    /// 
    /// different targetables and target systems (always target rooms, so only rooms have targetable 
    /// >   



    public Vector3 startingSize;
    public bool isHovering;
    public bool isSelected;


    public GameObject[] circles;

    private void Awake()
    {
        startingSize = transform.localScale;
    }


    private void Update()
    {
        if (isHovering)
        {

            if (InputSystem.actions["Click"].WasPressedThisFrame())
            {
                OnSelected();
            }
        }

        if (isSelected)
        {
            DrawCardTrajectory();
        }
    }
    public void DrawCardTrajectory()
    {
        Vector2 startPos = transform.position;
        Vector2 mousePos = UnityEngine.InputSystem.Mouse.current.position.ReadValue();

        Vector2 controlPoint = startPos + (mousePos - startPos) / 2f;
        controlPoint.y += 200f;

        for (int i = 0; i < circles.Length; i++)
        {
            float t = i / (float)(circles.Length - 1);

            Vector2 position = Mathf.Pow(1 - t, 2) * startPos +
                               2 * (1 - t) * t * controlPoint +
                               Mathf.Pow(t, 2) * mousePos;

            circles[i].transform.position = position;

            if (!circles[i].activeSelf)
            {
                circles[i].SetActive(true);
            }
        }
    }

    public void OnSelected()
    {
        isSelected = true;
        PlayerActionsManager.instance.SelectCard(this);

    }

    public void OnDeselected()
    {
        isSelected = false;
    }

  
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(startingSize * 1.2f, 0.2f);
        isHovering = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(startingSize, 0.2f);
        isHovering = false;

    }
}
