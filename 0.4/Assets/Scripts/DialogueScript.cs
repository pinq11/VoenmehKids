using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityStandardAssets.Characters.FirstPerson;

[Serializable]
public class DialogueObject
{
    public string[] Dialogues;
    public string CharacterName;
    public int questNumber;
}
namespace UnityStandartAssest.Characters.Firstperson
{
    public class DialogueScript : MonoBehaviour
    {
        public PlayerData data;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;
        public RigidbodyFirstPersonController rigid;
        public int currentNpc;
        private QuestOBJ obj;
        private int currentDialogueNum = 0;
        private DialogueObject curDialogue = null;

        [Header("Dialogue Objects")]
        public DialogueObject[] dialogue;

        [Header("NPCs")]
        public Interact[] npcs;


        private void Awake()
        {
            obj = FindObjectOfType<QuestOBJ>();
        }
        private void OnEnable()
        {
            switch (data.dialogueNumber)
            {
                case 0:
                    curDialogue = dialogue[0];
                    PlayDialogue(dialogue[0]);
                    break;
                case 1:
                    curDialogue = dialogue[1];
                    PlayDialogue(dialogue[1]);
                    break;
                case 2:
                    curDialogue = dialogue[2];
                    PlayDialogue(dialogue[2]);
                    break;
            }
        }
        void PlayDialogue(DialogueObject temp)
        {
            nameText.text = temp.CharacterName;
            if (currentDialogueNum < temp.Dialogues.Length)
            {
                dialogueText.text = temp.Dialogues[currentDialogueNum];
            }
            else
            {
                rigid.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                switch(data.dialogueNumber)
                {
                    case 0:
                        npcs[0].talked = true;
                        data.questNumber = 1;
                        obj.StartNewQuest(obj.quests[1]);
                        npcs[0].inDialogue = false;
                        break;
                    case 1:
                        {
                            npcs[0].inDialogue = false;
                            break;
                        }
                }
                data.dialogueNumber = 0;
                currentDialogueNum = 0;
                curDialogue = null;
                this.gameObject.SetActive(false);
            }
        }
        public void next()
        {
            if (curDialogue != null)
            {
                currentDialogueNum++;
                PlayDialogue((DialogueObject)curDialogue);
            }
        }
    }
}
