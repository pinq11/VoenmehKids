using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    public static PlayerData data;
    public static GameObject slot;

    public void Awake()
    {
        data = FindObjectOfType<PlayerData>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.pointerCurrentRaycast.screenPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        data.MoveItem(this.gameObject, slot);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slot = eventData.pointerEnter; 
    }
}
