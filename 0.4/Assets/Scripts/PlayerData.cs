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
    public float damage;
    public float armor;

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

    // лист врагов, наход€щихс€ в радиусе атаки
    public List<Skeleton> skeletons = new List<Skeleton>();

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

    // игрок получает урон
    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            // PlayerDeath();
            // печальный экран и вызов меню
        } 
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }

    // восстановление здоровь€
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
        if (inventory.AddItem(pickUpItem))
            return true;

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
            print(((InventorySlot)start).row + " " + ((InventorySlot)start).col);
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

        // если перекладываем в пустую €чейку
        if (temp2 == null)
            return;

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
            inventory.AddItem(temp2, ((InventorySlot)start).row, ((InventorySlot)start).col);
        }
    }

    private void Update()
    {
        // если покрутили колесиком
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            // перекрашиваем старую €чейку хотбара в дефолтный цвет
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

    // бьЄт всех врагов разом
    public void HitEnemy() 
    {
        if (skeletons.Count == 0)
            return;

        foreach (var skeleton in skeletons)
            skeleton.TakeDamage(damage);
    }

    // добавл€ет врага в список врагов, которые получают урон разом
    public void AddEnemyForHit(Skeleton skeleton) 
    {
        skeletons.Add(skeleton);
    }

    // аналогично удал€ет
    public void RemoveEnemyForHit(Skeleton skeleton) 
    { 
        skeletons.Remove(skeleton); 
    }


    // смерть игрока
    public void PlayerDeath()
    {
        // поставить игру на паузу
        // темнеющий экран активировать
        // по нажатию возвращать в меню
    }
}
