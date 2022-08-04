using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private const int MAX_ITEMS = 9;

    public HotbarSlot[] UI;
    private ObjectData[] items;

    private int curItem = 0;
    private int curItemsAmount = 0;

    public Color defaultColor;
    public Color selectedColor;

    public Hotbar ()
    {
        // этот строчка не нужна, ибо прикрепление предметов в инспекторе
        // юнити срабатывает после вызова конструктора
        //UI = new HotbarSlot[MAX_ITEMS];
        items = new ObjectData[MAX_ITEMS];
    }

    public bool IsFull() 
    {
        if (curItemsAmount == MAX_ITEMS)
            return true;

        return false; 
    }

    public bool AddItem(ObjectData addedItem)
    {
        if (IsFull())
            return false;

        for (int i = 0; i < MAX_ITEMS; i++)
            if (items[i] == null)
            {
                items[i] = addedItem;
                UI[i].icon.sprite = addedItem.sprite;
                curItemsAmount++;
                break;
            }

        return true;
    }

    public bool DeleteItem()
    {
        curItemsAmount--;
        return false;
    }

    public void SelectCurItem()
    {
        UI[curItem].background.color = selectedColor;
    }

    public void UnSeletctCurItem()
    {
        UI[curItem].background.color = defaultColor;
    }

    public void CurItemUp() 
    { 
        curItem++;
        curItem %= MAX_ITEMS;
    }

    public void CurItemDown() 
    { 
        curItem--;
        if (curItem < 0)
            curItem = MAX_ITEMS - 1;
    }
}
