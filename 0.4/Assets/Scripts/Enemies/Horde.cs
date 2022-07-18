using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    [Header("Enemies")]
    public Skeleton[] skeletons;

    public void Alert()
    {
        foreach (var skeleton in skeletons)
        {
            skeleton.alerted = true;
        }
    }
}
