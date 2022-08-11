using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class questData
{
    public string objective;
    public string title;
}

public class QuestOBJ : MonoBehaviour
{
    public GameObject questObject;
    public GameObject horde1;
    public GameObject horde2;
    public GameObject VillageNpcs;
    public GameObject UncleNpcs1;
    public GameObject RosaTrigger;
    public GameObject VillageTrigger;
    public GameObject UncleSkeletons;
    public GameObject UncleNpcs2;
    public GameObject BigSkeleton;
    public GameObject BeforeFather;
    public GameObject AfterRevenge;
    public GameObject AfterUncle;
    public GameObject AfterBigSkeleton;
    private PlayerData man;
    public TextMeshProUGUI questTitle, questObjective;
    public questData[] quests;
    private void Awake()
    {
        man = FindObjectOfType<PlayerData>(); //находим квесты на старте
    }
    public void StartNewQuest(questData data)
    {
        questTitle.text = data.title;
        questObjective.text = data.objective;
        questObject.SetActive(true);
        switch (man.questNumber)
        {
            case 1:
                {
                    horde1.SetActive(true);
                    BeforeFather.SetActive(false);
                    RosaTrigger.SetActive(true);
                    break;
                }
            case 2:
                {
                    horde2.SetActive(true);
                    VillageTrigger.SetActive(true);
                    VillageNpcs.SetActive(false);
                    break;
                }
            case 3:
                {
                    break;
                }
            case 4:
                {
                    UncleNpcs1.SetActive(true);
                    AfterRevenge.SetActive(false);
                    break;
                }
            case 5:
                {
                    UncleSkeletons.SetActive(true);
                    break;
                }
            case 6:
                {
                    UncleNpcs1.SetActive(false);
                    UncleNpcs2.SetActive(true );
                    break;
                }
            case 7:
                {
                    BigSkeleton.SetActive(true);
                    AfterUncle.SetActive(false);
                    break;
                }
            case 8:
                {
                    break;
                }
            case 9:
                {
                    AfterBigSkeleton.SetActive(false);
                    break;
                }
                
        }
        Invoke("CloseQuest", 6);
    }
    public void CloseQuest()
    {
        questObject.SetActive(false);
    }
}
