using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int MAX_ROW = 3;
    private const int MAX_COL = 3;

    public InventorySlot[] UI;
    private ObjectData[,] items;

    public Inventory()
    {
        items = new ObjectData[MAX_ROW, MAX_COL];
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

        return deleted;
    }

    public void AddItem(ObjectData item, int row, int col)
    {
        items[row, col] = item;
        if (item == null)
        {
            UI[row * MAX_ROW + col].icon.sprite = null;
        }
        else
        {
            UI[row * MAX_ROW + col].icon.sprite = item.sprite;
        }
    }
}
