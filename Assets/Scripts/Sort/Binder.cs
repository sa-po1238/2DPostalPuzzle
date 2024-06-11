using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Binder : MonoBehaviour, IPointerClickHandler
{
    private bool isClicked = false;
    private Vector3 defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        if (isClicked)
        {
            this.transform.DOMoveY(defaultPosition.y, 0.5f);
            isClicked = false;
        }
        else
        {
            this.transform.DOMoveY(100, 0.5f);
            isClicked = true;
        }
    }
}
