using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public int questNumber;
    public int dialogueNumber;

    [Header("PlayerStats")]
    public float maxHealth;
    public float curHealth;

    [Header("UIComponents")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText; 

    public void Start()
    {
        healthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        if (curHealth <= 0)
        {
            // PlayerDeath();
        } 
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }

    public void Heal(float treating)
    {
        curHealth += treating;
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }
}
