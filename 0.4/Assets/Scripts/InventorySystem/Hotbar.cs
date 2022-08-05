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
        items = new ObjectData[MAX_ITEMS];
    }

    public bool IsFull() 
    {
        if (curItemsAmount == MAX_ITEMS)
            return true;

        return false; 
    }

    public ObjectData GetItemByIndex(int index) 
    {
        if (index < 0 || index >= MAX_ITEMS)
            throw new System.ArgumentOutOfRangeException();

        return items[index]; 
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

    public void AddItemByIndex(ObjectData addedItem, int index)
    {
        if (index < 0 || index >= MAX_ITEMS)
            throw new System.ArgumentOutOfRangeException();

        items[index] = addedItem;
        UI[index].icon.sprite = addedItem.sprite;
        curItemsAmount++;
    }

    public void DeleteItem(int index)
    {
        if (index < 0 || index >= MAX_ITEMS)
            throw new System.ArgumentOutOfRangeException();

        items[index] = null;
        UI[index].icon.sprite = null;
        curItemsAmount--;
    }

    // заменяет два предмета их хотбара между собой
    public void Replace(int startIndex, int finishIndex)
    {
        if (startIndex < 0 || startIndex >= MAX_ITEMS)
            throw new System.ArgumentOutOfRangeException();

        if (finishIndex < 0 || finishIndex >= MAX_ITEMS)
            throw new System.ArgumentOutOfRangeException();

        Sprite tempUI = UI[startIndex].icon.sprite;
        UI[startIndex].icon.sprite = UI[finishIndex].icon.sprite;
        UI[finishIndex].icon.sprite = tempUI;

        ObjectData tempItem = items[startIndex];
        items[startIndex] = items[finishIndex];
        items[finishIndex] = tempItem;
    }

    // помечает текущий предмет хотбара цветом
    public void SelectCurItem()
    {
        UI[curItem].background.color = selectedColor;
    }

    // возварщает дефолтный цвет ячейке хотбара
    public void UnSeletctCurItem()
    {
        UI[curItem].background.color = defaultColor;
    }

    // увеличивает текущий предмет на 1
    public void CurItemUp() 
    { 
        curItem++;
        curItem %= MAX_ITEMS;
    }

    // уменьшает текущий предмет на 1
    public void CurItemDown() 
    { 
        curItem--;
        if (curItem < 0)
            curItem = MAX_ITEMS - 1;
    }
}
