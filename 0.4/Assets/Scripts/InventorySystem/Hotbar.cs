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
        // поиск геймобжектов
        player = FindObjectOfType<PlayerData>();
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");

        // найстройка цвета
        defaultColor = new Color32(126, 123, 122, 255);
        selectedColor = new Color32(255, 115, 115, 145);

        // заполнение UI списка
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

    // добавляет предмет на первое попавшееся свободное место
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

    // добавляет предмет по индексу. Если там уже есть другой предмет
    // то заменяет его
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

    // удаляет предмет из хотбара, возвращая его
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

    // помечает текущий предмет хотбара цветом
    public void SelectCurItem()
    {
        UI[curItem].background.color = selectedColor;

        // настройка отображения префаба предмета
        if (items[curItem] != null)
        {
            currentEquiped = Instantiate(items[curItem].prefab);
            currentEquiped.transform.SetParent(cameraObj.transform);
            currentEquiped.transform.localPosition = items[curItem].prefab.transform.position;
            currentEquiped.transform.localRotation = items[curItem].prefab.transform.rotation;
        }

        // проверка на оружие
        if (items[curItem] as WeaponStats)
        {
            // обновляем дамаг главного героя
            player.damage = ((WeaponStats)items[curItem]).damage;

            // обновляем хитбокс (на самом деле ее лучше звать "зона удара")
            player.hitbox.GetComponent<BoxCollider>().size = new Vector3(
                ((WeaponStats)items[curItem]).hitboxX,
                ((WeaponStats)items[curItem]).hitboxY,
                ((WeaponStats)items[curItem]).hitboxZ);
        }
    }

    // возварщает дефолтный цвет ячейке хотбара
    public void UnSeletctCurItem()
    {
        UI[curItem].background.color = defaultColor;
        // удаляем префаб предмета
        if (currentEquiped != null)
            Destroy(currentEquiped);

        player.damage = 0;
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

    // бросает предмет на землю, используя префаб
    public void DropCurItem()
    {
        if (items[curItem] == null)
            return;
        print("1");
        Instantiate(items[curItem].groundItem, cameraObj.transform);
        print("2");
    }
}
