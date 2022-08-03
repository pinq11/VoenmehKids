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
    [System.Serializable]
    public struct Hotbar
    {
        public ObjectData[] data;
        // их иконки
        public Image[] images;
        public Image[] backgrounds;
        public int curItem;
        public int maxItem;
        public int minItem;
        public Color defaultColor;
        public Color selectedColor;
    }
    [Header("Hotbar")]
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

    }

    public void Start()
    {
        // настройка здоровь€
        healthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");

        // настройка хотбара
        hotbar.backgrounds[hotbar.curItem].color = hotbar.selectedColor;
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
        for (int i = 0; i < hotbar.data.Length; i++)
            if (hotbar.data[i] == null)
            {
                hotbar.data[i] = pickUpItem;
                hotbar.images[i].sprite = pickUpItem.sprite;
                break;
            }

        // потом провер€ем инвентарь, если не было места в хотбаре

        // возвращаем удалось ли запихать в инвентарь
        return true;
    }

    // драг и дроп предметов в инвентаре
    public void MoveItem(GameObject start, GameObject finish)
    {
        //start.
    }

    private void Update()
    {
        // если покрутили колесиком
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            // перекрашиваем старый в дефолтный цвет
            hotbar.backgrounds[hotbar.curItem].color = hotbar.defaultColor;

            // мен€ем curItem
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                hotbar.curItem = (hotbar.curItem - 1 < hotbar.minItem) ? hotbar.maxItem : hotbar.curItem - 1;
            else
                hotbar.curItem = (hotbar.curItem + 1 > hotbar.maxItem) ? 0 : hotbar.curItem + 1;
            
            // красим новый выбранный предмет
            hotbar.backgrounds[hotbar.curItem].color = hotbar.selectedColor;
        }
    }
}
