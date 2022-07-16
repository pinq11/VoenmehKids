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
    public TextMeshProUGUI questTitle, questObjective;
    public questData[] quests;
    public void StartNewQuest(questData data)
    {
        questTitle.text = data.title;
        questObjective.text = data.objective;
        questObject.SetActive(true);
        Invoke("CloseQuest", 6);
    }
    public void CloseQuest()
    {
        questObject.SetActive(false);
    }
}
