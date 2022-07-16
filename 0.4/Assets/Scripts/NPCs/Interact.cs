using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace UnityStandartAssest.Characters.Firstperson
{
    public class Interact : MonoBehaviour
    {
        public GameObject triggerText;
        public GameObject dialogueObject;
        public RigidbodyFirstPersonController rigid;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                triggerText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    other.GetComponent<PlayerData>().dialogueNumber = 1;
                    dialogueObject.SetActive(true);
                    rigid.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            triggerText.SetActive(false);
        }
    }
}

