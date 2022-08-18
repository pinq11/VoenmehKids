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
        public GameObject wayPoint;
        public GameObject hotBar;
        public GameObject healthSlider;
        public RigidbodyFirstPersonController rigid;

        private void Start()
        {
            rigid.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Awake()
        {
            wayPoint.SetActive(false);
            hotBar.SetActive(false);
            healthSlider.SetActive(false);
        }   

        public void newgame()
        {
            rigid.transform.position = new Vector3((float)129.24, (float)4.7, (float)100.14);
            rigid.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            end1.SetActive(true);
            end2.SetActive(true);

            wayPoint.SetActive(true);
            hotBar.SetActive(true);
            healthSlider.SetActive(true);

            Time.timeScale = 1;

            menu.SetActive(false);
        }

        public void Load()
        {

        }

        public void Exit()
        {
            Application.Quit();
        }


    }
}

