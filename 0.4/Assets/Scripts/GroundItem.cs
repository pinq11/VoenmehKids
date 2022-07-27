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
    }

    private void OnTriggerStay(Collider other)
    {
        // показывает текст на экране перед игроком
        if (!isPickedUp)
        {
            triggerText.gameObject.SetActive(true);
            triggerText.text = "Нажмите E, чтобы подобрать " + itemName;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            data.PickUpItem(pickupItem);
            // че-та неприкольный цикл, надо перерабоать
            for (int i = 0; i < data.hotBar.Length; i++)
            {
                if (data.hotBar[i] == null)
                {
                    // нужно, чтобы здесь предмет клался либо в хотбар
                    // либо в инвентарь игрока
                    data.hotBar[i] = pickupItem;
                    triggerText.gameObject.SetActive(false);
                    isPickedUp = true;
                    Destroy(parent);
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerText.gameObject.SetActive(false);
    }
}
