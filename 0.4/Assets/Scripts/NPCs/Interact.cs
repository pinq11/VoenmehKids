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
        public bool talked = false;
        public bool inDialogue = false;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (!inDialogue)
                {
                    triggerText.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inDialogue = true;
                    if (!talked)
                    {
                        other.GetComponent<PlayerData>().dialogueNumber = 1;
                        dialogueObject.SetActive(true);
                        rigid.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        triggerText.SetActive(false);
                    }
                    else
                    {
                        other.GetComponent<PlayerData>().dialogueNumber = 2;
                        dialogueObject.SetActive(true);
                        rigid.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        triggerText.SetActive(false);
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            triggerText.SetActive(false);
        }
    }
}

