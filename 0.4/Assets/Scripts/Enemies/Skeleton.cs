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
    private Vector3 diff;
    private Vector3 idlecheck;
    private float updateTime = 0;
    public bool alerted = false;
    public float check;
    public float radiuscos=0;
    public float radiussin=0;
    void Start()
    {
        animator.SetBool("Idle", true);
        lastpos = this.transform.position;
        nav = GetComponent<NavMeshAgent>();
    }
    public void Update()
    {
        idlecheck = transform.position - lastpos;
        updateTime += Time.deltaTime;
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        check = idlecheck.magnitude;
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
                transform.LookAt(player.transform);
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
        if (!alerted && idlecheck.magnitude<2)
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
            {
                diff = new Vector3(player.transform.position.x + radiuscos, player.transform.position.y, player.transform.position.z +radiussin);
                nav.destination = diff;
            }
                
            updateTime = 0;
        }
    }




}
