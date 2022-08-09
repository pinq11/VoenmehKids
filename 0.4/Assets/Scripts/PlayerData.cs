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

    // �������� �������� ������� ������
    public Hotbar hotbar;

    public Equipment equipment;

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
        

        // ���������� ������� �� �������� � ���������
        return false;
    }

    // ���� � ���� ��������� � ���������
    public void MoveItem(Slot start, Slot finish)
    {
        if (start is HotbarSlot a && finish is HotbarSlot b)
        {
            print(a.index);
            print(b.index);
            hotbar.Replace(a.index, b.index);
            return;
        } 

        if (start is EquipmentSlot a && finish is EquipmentSlot b)
        {
            equipment.Replace(a.name, b.name);
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
    }
}
