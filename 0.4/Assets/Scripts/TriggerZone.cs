using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private QuestOBJ obj;
    private PlayerData playerData;
    private void Awake()
    {
        obj = FindObjectOfType<QuestOBJ>(); //находим квесты на старте
        playerData = FindObjectOfType<PlayerData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            obj.StartNewQuest(obj.quests[++playerData.questNumber]);
            this.gameObject.SetActive(false); //убираем зону
        }
    }
}
