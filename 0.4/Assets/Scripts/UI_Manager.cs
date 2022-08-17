using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject InventorySystem;

    /*private void Start()
    {
        InventorySystem = GameObject.FindGameObjectWithTag("InventorySystem");
        print(InventorySystem);
    }*/

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
    }
}
