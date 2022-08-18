using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    private int number = 0;
    private int current = 0;
    [Header("Enemies")]
    public Skeleton[] skeletons;

    // Это Толя добавил
    public float minDamage;
    public float maxDamage;

    public bool questTrigger;
    public bool allDead = false;

    private QuestOBJ quest;
    private PlayerData player;

    public void Start()
    {
        foreach (var skeleton in skeletons)
        {
            number++;
        }
        foreach (var skeleton in skeletons)
        {
            skeleton.radiuscos = (float)(1.5 * Math.Cos(2*Math.PI*current/number));
            skeleton.radiussin = (float)(1.5 * Math.Sin(2 * Math.PI * current / number));
            current++;
        }
        player = FindObjectOfType<PlayerData>();
        quest = FindObjectOfType<QuestOBJ>();
    }

    public void Alert()
    {
        foreach (var skeleton in skeletons)
        {
            skeleton.alerted = true;
        }
    }

    private void Update()
    {
        allDead = true;

        foreach (var sceleton in skeletons)
            if (!sceleton.IsDead())
            {
                allDead = false;
                break;
            }
     
        if (allDead && questTrigger)
        {
            quest.StartNewQuest((quest.quests[++(player.questNumber)]));
        }
    }
}
