using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UI_Manager : MonoBehaviour
{
    public GameObject InventorySystem;
    public GameObject MainMenu; 
    public GameObject DeathScreen;
    public RigidbodyFirstPersonController rigid;
    public GameObject hotbar;
    public GameObject healthSlider;

    private void Start()
    {
        /*InventorySystem = GameObject.FindGameObjectWithTag("InventorySystem");
        print(InventorySystem);*/

    }

    void Update()
    {
        // включение инвентаря
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventorySystem.SetActive(!InventorySystem.activeSelf);

            if (InventorySystem.activeSelf)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!MainMenu.activeSelf)
                ShowMenu();
            else
                CloseMenu();
        }
    }

    public void ShowMenu()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        hotbar.SetActive(false);
        MainMenu.SetActive(true);
        healthSlider.SetActive(true);

        if (DeathScreen.activeSelf)
            DeathScreen.SetActive(false);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigid.enabled = true;
        hotbar.SetActive(true);
        healthSlider.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        healthSlider.SetActive(false);
        DeathScreen.SetActive(true);
    }
}
