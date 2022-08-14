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
    public GameObject Marker1;
    public GameObject Marker2;
    public GameObject Marker3;
    public GameObject Marker4;
    public GameObject Marker5;
    public GameObject Marker6;
    public GameObject Marker7;
    public GameObject Marker8;
    public GameObject Marker9;
    private WayPoint wayPoint;
    private PlayerData man;
    public TextMeshProUGUI questTitle, questObjective;
    public questData[] quests;
    private void Awake()
    {
        man = FindObjectOfType<PlayerData>(); //находим квесты на старте
        wayPoint = FindObjectOfType<WayPoint>();
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
                    wayPoint.chagnepos(Marker2.transform);
                    break;
                }
            case 2:
                {
                    horde2.SetActive(true);
                    VillageTrigger.SetActive(true);
                    VillageNpcs.SetActive(false);
                    wayPoint.chagnepos(Marker3.transform);
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
                    wayPoint.chagnepos(Marker4.transform);
                    break;
                }
            case 5:
                {
                    UncleSkeletons.SetActive(true);
                    wayPoint.chagnepos(Marker5.transform);
                    break;
                }
            case 6:
                {
                    UncleNpcs1.SetActive(false);
                    UncleNpcs2.SetActive(true );
                    wayPoint.chagnepos(Marker6.transform);
                    break;
                }
            case 7:
                {
                    BigSkeleton.SetActive(true);
                    AfterUncle.SetActive(false);
                    wayPoint.chagnepos(Marker7.transform);
                    break;
                }
            case 8:
                {
                    wayPoint.chagnepos(Marker8.transform);
                    break;
                }
            case 9:
                {
                    wayPoint.chagnepos(Marker9.transform);
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
