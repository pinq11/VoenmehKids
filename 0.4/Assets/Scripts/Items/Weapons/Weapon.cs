using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerData player;

    public WeaponStats weapon;
    public Animator animator;

    public bool isAttacking = false;


    private void Start()
    {
        player = FindObjectOfType<PlayerData>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(weapon.attackTime);
            animator.SetBool("isAttacking", false);
            isAttacking = false;
        }
    }

    public void HitEnemy()
    {
        print("I hitted the enemy!");
        player.HitEnemy();
    }
}
