using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;
    public Horde horde;
    public Animator animator;
    private Vector3 lastpos;
    private float updateTime = 0;
    public bool alerted = false;
    public float check;
    void Start()
    {
        animator.SetBool("Idle", true);
        lastpos = this.transform.position;
        nav = GetComponent<NavMeshAgent>();
    }
    public void Update()
    {
        updateTime += Time.deltaTime;
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        check = distance;
        if ((distance <=10.0)&&(!alerted))
        {
                horde.Alert();
        }
        if (alerted)
        {
            animator.SetBool("Idle", false);
            if (distance < 3.0)
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Attack", true);
            }
            else if (distance > 20.0)
            {
                nav.destination = lastpos;
                alerted = false;
            }
            else
            {
                animator.SetBool("Attack", false);
                animator.SetBool("Walking", true);
            }
        }
        if (!alerted && lastpos.Equals(this.transform.position))
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
        }
        
    }
    private void LateUpdate()
    {
        if (updateTime > 1)
        {
            if (alerted)
                nav.destination = player.transform.position;
            updateTime = 0;
        }
    }




}
