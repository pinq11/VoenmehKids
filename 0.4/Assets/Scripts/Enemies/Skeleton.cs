using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;
    public Horde horde;
    private Vector3 lastpos;
    private float updateTime = 0;
    public bool alerted = false;
    public bool idle = true;
    public float check;
    void Start()
    {
        lastpos = this.transform.position;
        nav = GetComponent<NavMeshAgent>();
    }
    public void Update()
    {
        updateTime += Time.deltaTime;
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        check = distance;
        if ((distance <=20.0)&&(!alerted))
        {
            if (idle)
            {
                horde.Alert();
                idle = false;
            }     
        }
        else if(distance >50.0)
        {
            if(!idle)
            {
                idle = true;
                nav.destination = lastpos;
                alerted = false;
            }
        }
    }
    private void LateUpdate()
    {
        if (updateTime > 1)
        {
            if (alerted)
                nav.destination = player.transform.position;
            else
                lastpos = this.transform.position;
            updateTime = 0;
        }
    }




}
