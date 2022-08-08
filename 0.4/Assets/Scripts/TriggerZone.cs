using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private QuestOBJ obj;
    private PlayerData playerData;
    public int TriggerNumber; //����� ���� � ������� ������ �����
    private void Awake()
    {
        obj = FindObjectOfType<QuestOBJ>(); //������� ������ �� ������
        playerData = FindObjectOfType<PlayerData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch(TriggerNumber) //������������� ����� � ����������� �� ����
            {
                case 1:
                    {
                        playerData.questNumber = 1;
                        obj.StartNewQuest(obj.quests[1]);
                        break;
                    }
                case 2:
                    {
                        playerData.questNumber = 2;
                        obj.StartNewQuest(obj.quests[2]);
                        break;
                    }
                case 7:
                    {
                        playerData.questNumber = 7;
                        obj.StartNewQuest(obj.quests[7]);
                        break;
                    }
            }
            playerData.questNumber++;
            this.gameObject.SetActive(false); //������� ����
        }
    }
}
