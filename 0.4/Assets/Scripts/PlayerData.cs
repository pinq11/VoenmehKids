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

    [System.Serializable]
    public struct InventoryItem
    {
        public ObjectData data;
        public Image image;
        public Image background;
    }

    // предметы быстрого доступа игрока
    public Hotbar hotbar;

    [System.Serializable]
    public struct Equipment
    {
        public InventoryItem helmet;
        public InventoryItem armor;
        public InventoryItem boots;

        public InventoryItem leftRing;
        public InventoryItem rightRing;
    }
    [Header("Equipment")]
    public Equipment equipment;

    public struct Inventory
    {
        public InventoryItem[,] inventory;
    }

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
        hotbar.AddItem(pickUpItem);

        // потом провер€ем инвентарь, если не было места в хотбаре

        // возвращаем удалось ли запихать в инвентарь
        return true;
    }

    // драг и дроп предметов в инвентаре
    public void MoveItem(Slot start, Slot finish)
    {
        //start.
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
    }
}
