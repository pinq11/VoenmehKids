using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[SerializeField]
public class DialogueObject
{
    public string[] Dialogues;
    public string CharacterName;
    public int questNumber;
}
public class DialogueScript : MonoBehaviour
{
    private PlayerData data;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private int currentDialogueNum = 0;
    private DialogueObject curDialogue=null;

    [Header("Dialogue Objects")]
    public DialogueObject dialogue1;
    private void Start()
    {
        data = FindObjectOfType<PlayerData>();
    }
    private void OnEnable()
    {
        switch (data.dialogueNumber)
        {
            case 1:
                curDialogue = dialogue1;
                PlayDialogue(dialogue1);
                break;
        }
    }
    void PlayDialogue(DialogueObject temp)
    {
        nameText.text = temp.CharacterName;
        if (currentDialogueNum<temp.Dialogues.Length)
        {
            dialogueText.text = temp.Dialogues[currentDialogueNum];
        }
        else
        {
            //end;
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
