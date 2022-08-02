using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    public static PlayerData data;

    public void Awake()
    {
        data = FindObjectOfType<PlayerData>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        data.MoveItem();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(name + "Enter");
    }
}
