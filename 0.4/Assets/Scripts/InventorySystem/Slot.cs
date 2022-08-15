using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, 
                             IEndDragHandler, IPointerEnterHandler
{
    private static PlayerData data;
    private static Slot finish;
    private static Vector3 startPosition;

    public Image icon;
    public Image background;

    public void Awake()
    {
        data = FindObjectOfType<PlayerData>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;  
    }

    public void OnDrag(PointerEventData eventData)
    {
        // по оси z на первое место
        // нельзя перетаскивать пустые слоты
        if (icon.sprite == null)
            return;

        transform.position = eventData.pointerCurrentRaycast.screenPosition;   
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (icon.sprite == null)
            return;

        data.MoveItem(this, finish);
        transform.position = startPosition;
    }

    // здесь создадим новый UI
    /*public void OnPointerDown(PointerEventData eventData)
    {
        
    }*/

    public void OnPointerEnter(PointerEventData eventData)
    {
        print(this);
        finish = this;
    }
}
