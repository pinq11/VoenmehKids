using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject InventorySystem;
    public GameObject MainMenu;
    public GameObject DeathScreen;

    /*private void Start()
    {
        InventorySystem = GameObject.FindGameObjectWithTag("InventorySystem");
        print(InventorySystem);
    }*/

    void Update()
    {
        // ��������� ���������
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
        MainMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MainMenu.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DeathScreen.SetActive(true);
    }
}
