using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StackItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 initialPosition;    
    private CanvasGroup canvasGroup;    

    private void Awake()
    {
        initialPosition = transform.position;  
        canvasGroup = GetComponent<CanvasGroup>();  
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        canvasGroup.blocksRaycasts = false; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;  
        if (!IsDroppedInValidArea()) 
        {
            transform.position = initialPosition;  
        }
    }

    private bool IsDroppedInValidArea()
    {
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition  
        };
        EventSystem.current.RaycastAll(pointerEventData, results);  

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("StackArea")) 
            {
                return true;    
            }
        }
        return false;   
    }
}
