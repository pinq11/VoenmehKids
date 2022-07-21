using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundItem : MonoBehaviour
{
    public TextMeshProUGUI triggerText;
    public new string name;

    private void OnTriggerStay(Collider other)
    {
        triggerText.gameObject.SetActive(true);
        triggerText.text = "Нажмите E, чтобы подобрать " + name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerText.gameObject.SetActive(false);
    }
}
