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
            case 0:
                {
                    horde1.SetActive(true);
                    break;
                }
            case 1:
                {
                    horde2.SetActive(true);
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
