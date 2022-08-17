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

    public Color32 defaultColor;
    public Color32 selectedColor;

    private GameObject currentEquiped;
    public GameObject cameraObj;

    public PlayerData player;

    private void Start()
    {
        // ����� ������������
        player = FindObjectOfType<PlayerData>();
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");

        // ���������� �����
        defaultColor = new Color32(126, 123, 122, 255);
        selectedColor = new Color32(255, 115, 115, 145);

        // ���������� UI ������
        /*UI = new HotbarSlot[MAX_ITEMS];
        for (int i = 0; i < MAX_ITEMS; i++)
        {
            UI[i] = this.transform.ch
        }*/
    }

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

    // ��������� ������� �� ������ ���������� ��������� �����
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

    // ��������� ������� �� �������. ���� ��� ��� ���� ������ �������
    // �� �������� ���
    public void AddItemByIndex(ObjectData addedItem, int index)
    {
        if (index < 0 || index >= MAX_ITEMS)
            throw new System.ArgumentOutOfRangeException();

        if (items[index] == null)
            curItemsAmount++;

        items[index] = addedItem;

        if (addedItem == null)
            UI[index].icon.sprite = null;
        else
            UI[index].icon.sprite = addedItem.sprite;
    }

    // ������� ������� �� �������, ��������� ���
    public ObjectData DeleteItem(int index)
    {
        if (index < 0 || index >= MAX_ITEMS)
            throw new System.ArgumentOutOfRangeException();

        ObjectData deleted = items[index];

        items[index] = null;
        UI[index].icon.sprite = null;
        curItemsAmount--;

        return deleted;
    }

    // �������� ������� ������� ������� ������
    public void SelectCurItem()
    {
        UI[curItem].background.color = selectedColor;

        // ��������� ����������� ������� ��������
        if (items[curItem] != null)
        {
            currentEquiped = Instantiate(items[curItem].prefab);
            currentEquiped.transform.SetParent(cameraObj.transform);
            currentEquiped.transform.localPosition = items[curItem].prefab.transform.position;
            currentEquiped.transform.localRotation = items[curItem].prefab.transform.rotation;
        }

        // �������� �� ������
        if (items[curItem] as WeaponStats)
        {
            // ��������� ����� �������� �����
            player.damage = ((WeaponStats)items[curItem]).damage;

            // ��������� ������� (�� ����� ���� �� ����� ����� "���� �����")
            player.hitbox.GetComponent<BoxCollider>().size = new Vector3(
                ((WeaponStats)items[curItem]).hitboxX,
                ((WeaponStats)items[curItem]).hitboxY,
                ((WeaponStats)items[curItem]).hitboxZ);
        }
    }

    // ���������� ��������� ���� ������ �������
    public void UnSeletctCurItem()
    {
        UI[curItem].background.color = defaultColor;
        // ������� ������ ��������
        if (currentEquiped != null)
            Destroy(currentEquiped);

        player.damage = 0;
    }

    // ����������� ������� ������� �� 1
    public void CurItemUp() 
    { 
        curItem++;
        curItem %= MAX_ITEMS;
    }

    // ��������� ������� ������� �� 1
    public void CurItemDown() 
    { 
        curItem--;
        if (curItem < 0)
            curItem = MAX_ITEMS - 1;
    }

    // ������� ������� �� �����, ��������� ������
    public void DropCurItem()
    {
        if (items[curItem] == null)
            return;
        print("1");
        Instantiate(items[curItem].groundItem, cameraObj.transform);
        print("2");
    }
}
