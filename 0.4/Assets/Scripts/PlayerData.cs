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
    // �������� �������� ������� ������
    public Hotbar hotbar;

    // ������� ���������� ������
    public Equipment equipment;

    // ���� � "�������"
    public Inventory inventory;

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
        if (hotbar.AddItem(pickUpItem))
            return true;

        // ����� ��������� ���������, ���� �� ���� ����� � �������
        //if ()

        // ���������� ������� �� �������� � ���������
        return false;
    }

    // ���� � ���� ��������� � ���������
    public void MoveItem(Slot start, Slot finish)
    {
        ObjectData temp = null;
        // �������� � ������� ������� �� ��������� ������
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
        // ��������� ������� � �������� ������, ����� ���� ������ �� ����������
        if (finish as HotbarSlot)
        {
            temp2 = hotbar.DeleteItem(((HotbarSlot)finish).index);
            hotbar.AddItemByIndex(temp, ((HotbarSlot)finish).index);
        }
        else if (finish as EquipmentSlot)
        {
            temp2 = equipment.RemoveArmor(((EquipmentSlot)finish).armorType);
            // �������� �� ���������� ��� ������ �������
            equipment.PutOnArmor(temp, ((EquipmentSlot)finish).armorType);
        }
        else
        {
            temp2 = inventory.DeleteItem(((InventorySlot)finish).row, ((InventorySlot)finish).col);
            inventory.AddItem(temp, ((InventorySlot)finish).row, ((InventorySlot)finish).col);
        }

        // � ��������� ������ �������� ���������� ��������
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

        // �� q �������� ������� ������� �� �������
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hotbar.DropCurItem();
        }
    }
}
