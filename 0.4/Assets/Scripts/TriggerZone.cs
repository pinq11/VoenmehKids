using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private QuestOBJ obj;
    public int TriggerNumber;
    private void Awake()
    {
        obj = FindObjectOfType<QuestOBJ>();
    }
}
