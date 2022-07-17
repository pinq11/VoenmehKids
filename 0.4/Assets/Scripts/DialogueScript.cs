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
        private QuestOBJ obj;
        private int currentDialogueNum = 0;
        private DialogueObject curDialogue = null;

        [Header("Dialogue Objects")]
        public DialogueObject dialogue1;
        public DialogueObject dialogue2;

        [Header("NPCs")]
        public Interact npc1;


        private void Awake()
        {
            obj = FindObjectOfType<QuestOBJ>();
        }
        private void OnEnable()
        {
            switch (data.dialogueNumber)
            {
                case 1:
                    curDialogue = dialogue1;
                    PlayDialogue(dialogue1);
                    break;
                case 2:
                    curDialogue = dialogue2;
                    PlayDialogue(dialogue2);
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
                    case 1:
                        npc1.talked = true;
                        obj.StartNewQuest(obj.quests[0]);
                        break;
                }
                data.dialogueNumber = 0;
                currentDialogueNum = 0;
                data.questNumber = curDialogue.questNumber;
                curDialogue = null;
                npc1.inDialogue = false;
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
