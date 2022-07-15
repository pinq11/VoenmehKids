using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject dialogueObject;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            triggerText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                dialogueObject.SetActive(true);
                triggerText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        triggerText.SetActive(false);
    }
}
