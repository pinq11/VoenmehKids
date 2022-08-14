using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ending : MonoBehaviour
{
    public GameObject end;
    public GameObject menu;
    public RigidbodyFirstPersonController rigid;
    private bool entered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if (!entered)
            {
                rigid.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                end.SetActive(true);
                entered = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu.SetActive(true);
                end.SetActive(false);
                entered = false;
                this.gameObject.SetActive(false);
            }
        }
    }
}
