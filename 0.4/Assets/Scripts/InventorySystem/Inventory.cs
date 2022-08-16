using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int MAX_ROW = 3;
    private const int MAX_COL = 3;
    private const int MAX_ITEMS_AMOUNT = 9;

    public InventorySlot[] UI;
    private ObjectData[,] items;

    private int curItemsAmount = 0;

    public Inventory()
    {
        items = new ObjectData[MAX_ROW, MAX_COL];
    }

    public bool IsFull()
    {
        return curItemsAmount == MAX_ITEMS_AMOUNT;
    }

    public ObjectData DeleteItem(int row, int col)
    {
        if (row < 0 || row >= MAX_ROW)
            throw new System.ArgumentOutOfRangeException();

        if (col < 0 || col >= MAX_COL)
            throw new System.ArgumentOutOfRangeException();

        ObjectData deleted = items[row, col];

        items[row, col] = null;
        UI[row * MAX_ROW + col].icon.sprite = null;

        curItemsAmount--;

        return deleted;
    }

    public bool AddItem(ObjectData item)
    {
        if (IsFull())
            return false;

        for (int row = 0; row < MAX_ROW; row++)
            for (int col = 0; col < MAX_COL; col++)
                if (items[row, col] == null)
                {
                    items[row, col] = item;
                    UI[row * MAX_ROW + col].icon.sprite = item.sprite;
                }
        curItemsAmount++;

        return true;
    }

    // добавляет предмет в нужный ряд и колонку
    public bool AddItem(ObjectData item, int row, int col)
    {
        if (IsFull())
            return false;

        if (row < 0 || row >= MAX_ROW)
            throw new System.ArgumentOutOfRangeException();

        if (col < 0 || col >= MAX_COL)
            throw new System.ArgumentOutOfRangeException();

        items[row, col] = item;
        if (item == null)
        {
            UI[row * MAX_ROW + col].icon.sprite = null;
        }
        else
        {
            UI[row * MAX_ROW + col].icon.sprite = item.sprite;
        }

        curItemsAmount++;

        return true;
    }
}
