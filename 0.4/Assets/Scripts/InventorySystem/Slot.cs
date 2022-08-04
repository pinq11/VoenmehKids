using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    public static PlayerData data;
    public static Slot finish;
    public Image icon;
    public Image background;

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
        data.MoveItem(this, finish);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        finish = this;
    }
}
