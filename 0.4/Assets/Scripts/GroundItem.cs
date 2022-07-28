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
            if (data.PickUpItem(pickupItem))
            {
                triggerText.gameObject.SetActive(false);
                isPickedUp = true;
                Destroy(parent);
            }
            
            // вот здесь если предмет подобран, то 
            
            // иначе будет продолжать гореть
            // data.PickUpItem(pickupItem) вернет bool подобран или нет предмет
        }
    }

    private void OnTriggerExit(Collider other)
    {
        triggerText.gameObject.SetActive(false);
    }
}
