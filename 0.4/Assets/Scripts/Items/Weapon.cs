using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectData weapon;
    public Animator animator;

    public bool isAttacking = false;

    // Update is called once per frame
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
            isAttacking = false;
        }
    }
}
