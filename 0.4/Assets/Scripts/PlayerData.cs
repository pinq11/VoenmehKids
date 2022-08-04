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

    // �������� �������� ������� ������
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
        // ��������� ��������
        healthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");

        // ��������� �������
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

    // ���������, ���� �������� �������: � ������, ��� � ���������, ��� ����� ���
    public bool PickUpItem(ObjectData pickUpItem)
    {
        // ������� ��������� ������, ���� ���� ��������� ������
        // �� ������ � ���
        hotbar.AddItem(pickUpItem);

        // ����� ��������� ���������, ���� �� ���� ����� � �������

        // ���������� ������� �� �������� � ���������
        return true;
    }

    // ���� � ���� ��������� � ���������
    public void MoveItem(Slot start, Slot finish)
    {
        //start.
    }

    private void Update()
    {
        // ���� ��������� ���������
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            // ������������� ������ � ��������� ����
            hotbar.UnSeletctCurItem();

            // ������ curItem
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                hotbar.CurItemDown();
            else
                hotbar.CurItemUp();

            // ������ ����� ��������� �������
            hotbar.SelectCurItem();
        }
    }
}
