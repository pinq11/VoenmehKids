using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public int questNumber;
    public int dialogueNumber;

    [Header("PlayerStats")]
    public float maxHealth;
    public float curHealth;

    [Header("UIComponents")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI triggerText;

    [Header("InventorySystem")]
    // предметы быстрого доступа игрока
    public Hotbar hotbar;

    // надета€ экипировка игрока
    public Equipment equipment;

    // вещи в "рюкзаке"
    public Inventory inventory;

    public void Start()
    {
        // настройка здоровь€
        healthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");

        // настройка хотбара
        hotbar.SelectCurItem();
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            // PlayerDeath();
        } 
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }

    public void Heal(float treating)
    {
        curHealth += treating;
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }

    // подбирает, куда засунуть предмет: в хотбар, или в инвентарь, или места нет
    public bool PickUpItem(ObjectData pickUpItem)
    {
        // сначала провер€ем хотбар, если есть свободна€ €чейка
        // то кладем в нее
        if (hotbar.AddItem(pickUpItem))
            return true;

        // потом провер€ем инвентарь, если не было места в хотбаре
        //if ()

        // возвращаем удалось ли запихать в инвентарь
        return false;
    }

    // драг и дроп предметов в инвентаре
    public void MoveItem(Slot start, Slot finish)
    {
        ObjectData temp = null;
        // забираем и удал€ем предмет из начальной €чейки
        if (start as HotbarSlot)
        {
            temp = hotbar.DeleteItem(((HotbarSlot)start).index);
        }
        else if (start as EquipmentSlot)
        {
            temp = equipment.RemoveArmor(((EquipmentSlot)start).armorType);
        }
        else
        {
            temp = inventory.DeleteItem(((InventorySlot)start).row, ((InventorySlot)start).col);
        }

        ObjectData temp2 = null;
        // вставл€ем предмет в конечную €чейку, перед этим забрав ее содержимое
        if (finish as HotbarSlot)
        {
            temp2 = hotbar.DeleteItem(((HotbarSlot)finish).index);
            hotbar.AddItemByIndex(temp, ((HotbarSlot)finish).index);
        }
        else if (finish as EquipmentSlot)
        {
            temp2 = equipment.RemoveArmor(((EquipmentSlot)finish).armorType);
            // проверку на подход€щий тип армора сделать
            equipment.PutOnArmor(temp, ((EquipmentSlot)finish).armorType);
        }
        else
        {
            temp2 = inventory.DeleteItem(((InventorySlot)finish).row, ((InventorySlot)finish).col);
            inventory.AddItem(temp, ((InventorySlot)finish).row, ((InventorySlot)finish).col);
        }

        // в стартовую €чейку помещаем содержимое конечной
        if (start as HotbarSlot)
        {
            hotbar.AddItemByIndex(temp2, ((HotbarSlot)start).index);
        }
        else if (start as EquipmentSlot)
        {
            equipment.PutOnArmor(temp2, ((EquipmentSlot)start).armorType);
        }
        else
        {
            inventory.AddItem(temp, ((InventorySlot)start).row, ((InventorySlot)start).col);
        }
    }

    private void Update()
    {
        // если покрутили колесиком
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            // перекрашиваем старый в дефолтный цвет
            hotbar.UnSeletctCurItem();

            // мен€ем curItem
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                hotbar.CurItemDown();
            else
                hotbar.CurItemUp();

            // красим новый выбранный предмет
            hotbar.SelectCurItem();
        }

        // на q сбросить текущий предмет из хотбара
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hotbar.DropCurItem();
        }
    }
}
