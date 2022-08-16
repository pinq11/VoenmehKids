using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerData player;

    public ObjectData weapon;
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
            yield return new WaitForSeconds(weapon.animationTime);
            animator.SetBool("isAttacking", false);
            player.HitEnemy();
            isAttacking = false;
        }
    }
}
