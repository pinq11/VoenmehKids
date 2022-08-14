using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace UnityStandartAssest.Characters.Firstperson
{
    
    public class MainMenu : MonoBehaviour
    {
        public GameObject menu;
        public GameObject end1;
        public GameObject end2;
        public RigidbodyFirstPersonController rigid;
        private void Start()
        {
            rigid.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void newgame()
        {
            rigid.transform.position = new Vector3((float)129.24, (float)4.7, (float)100.14);
            rigid.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            end1.SetActive(true);
            end2.SetActive(true);
            menu.SetActive(false);
        }
    }
}

