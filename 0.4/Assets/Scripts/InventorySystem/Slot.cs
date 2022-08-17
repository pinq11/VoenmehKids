using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour, IPointerEnterHandler,
                             IPointerDownHandler, IPointerUpHandler
{
    private static GameObject draggingSprite;
    private static PlayerData player;
    private static Slot finish;

    public Image icon;
    public Image background;

    public void Start()
    {
        player = FindObjectOfType<PlayerData>();

        // вручную создаем UI для drag&drop
        draggingSprite = new GameObject();
        draggingSprite.AddComponent<Image>();
        draggingSprite.GetComponent<Image>().raycastTarget = false;
        draggingSprite.transform.parent = GameObject.Find("UI_Panel").transform;
        draggingSprite.SetActive(false);

        // ищем icon и background
        icon = gameObject.GetComponent<Image>();
        background = transform.parent.GetComponent<Image>(); 
    }

    // здесь добавим спрайт
    public void OnPointerDown(PointerEventData eventData)
    {
        // нельзя перетаскивать слоты без спрайта
        if (icon.sprite == null)
            return;

        finish = this;

        draggingSprite.GetComponent<Image>().sprite = icon.sprite;
        draggingSprite.SetActive(true);
    }

    // здесь помечаем, в какой слот вошли
    public void OnPointerEnter(PointerEventData eventData)
    {
        finish = this;
    }

    // здесь удаляем временный UI и запускаем player.MoveItem(this, finish);
    public void OnPointerUp(PointerEventData eventData)
    {
        // нельзя перетаскивать слоты без спрайта
        if (icon.sprite == null)
            return;

        draggingSprite.SetActive(false);

        if (finish != this)
            player.MoveItem(this, finish);
    }

    private void Update()
    {
        if (draggingSprite.activeSelf)
            draggingSprite.transform.position = Input.mousePosition;
    }

}
