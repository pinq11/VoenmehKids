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
    // �������� �������� ������� ������
    public Hotbar hotbar;

    // ������� ���������� ������
    public Equipment equipment;

    // ���� � "�������"
    public Inventory inventory;

    // ���� ������, ����������� � ������� �����
    public List<Skeleton> skeletons = new List<Skeleton>();

    // ������� ("���� ����� ���������")
    public HitBox hitbox;

    public UI_Manager ui_manager;

    public void Start()
    {
        // ��������� ��������
        healthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");

        hitbox = FindObjectOfType<HitBox>();

        ui_manager = FindObjectOfType<UI_Manager>();

        // ��������� �������
        hotbar.SelectCurItem();
    }

    // ����� �������� ����
    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            PlayerDeath();
        } 
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }

    // �������������� ��������
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
        if (inventory.AddItem(pickUpItem))
            return true;

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

        // ���� ������������� � ������ ������
        if (temp2 == null)
            return;

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
            inventory.AddItem(temp2, ((InventorySlot)start).row, ((InventorySlot)start).col);
        }
    }

    private void Update()
    {
        // ���� ��������� ���������
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            // ������������� ������ ������ ������� � ��������� ����
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

    // ���� ���� ������ �����
    public void HitEnemy() 
    {
        if (skeletons.Count == 0)
            return;

        foreach (var skeleton in skeletons)
            skeleton.TakeDamage(damage);
    }

    // ��������� ����� � ������ ������, ������� �������� ���� �����
    public void AddEnemyForHit(Skeleton skeleton) 
    {
        skeletons.Add(skeleton);
    }

    // ���������� �������
    public void RemoveEnemyForHit(Skeleton skeleton) 
    { 
        skeletons.Remove(skeleton); 
    }


    // ������ ������
    public void PlayerDeath()
    {
        // ��������� ���� �� �����
        // ��������� ����� ������������
        // �� ������� ���������� � ����
        ui_manager.ShowDeathScreen();
    }
}
