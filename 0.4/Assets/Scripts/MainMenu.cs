using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace UnityStandartAssest.Characters.Firstperson
{
    
    public class MainMenu : MonoBehaviour
    {
        public GameObject menu;
        public RigidbodyFirstPersonController rigid;
        private void Start()
        {
            rigid.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void newgame()
        {
            rigid.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menu.SetActive(false);
        }
    }
}

