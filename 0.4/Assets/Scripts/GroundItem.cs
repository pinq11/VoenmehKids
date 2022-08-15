using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundItem : MonoBehaviour
{
    public TextMeshProUGUI triggerText;
    public new string itemName;
    public ObjectData pickupItem;

    private PlayerData data;

    public GameObject parent;

    private bool isPickedUp;

    private void Start()
    {
        data = FindObjectOfType<PlayerData>();
        triggerText = data.triggerText;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ���������� ����� �� ������ ����� �������
            if (!isPickedUp)
            {
                triggerText.gameObject.SetActive(true);
                triggerText.text = "������� E, ����� ��������� " + itemName;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (data.PickUpItem(pickupItem))
                {
                    triggerText.gameObject.SetActive(false);
                    isPickedUp = true;
                    Destroy(parent);
                }

                // ��� ����� ���� ������� ��������, �� 

                // ����� ����� ���������� ������
                // data.PickUpItem(pickupItem) ������ bool �������� ��� ��� �������
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            triggerText.gameObject.SetActive(false);
    }
}
