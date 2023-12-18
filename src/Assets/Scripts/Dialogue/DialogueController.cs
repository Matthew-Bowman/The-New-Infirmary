using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    // DECLARE sentences
    [SerializeField] private string[] initialDialogueSentences;
    [SerializeField] private string[] notEnoughDialogueSentences;
    [SerializeField] private string[] completedDialogueSentences;
    private string[] dialogue;
    private LevelOneDialogue type;

    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Text dialogueContainer;

    // DECLARE dialogue flags
    private bool initialDialogue = false;
    private bool inProgress = false;

    private int index;

    private Resources resources;

    private void Start()
    {
        resources = GetComponent<Resources>();
    }

    public void StartDialogue()
    {
        if (!inProgress)
        {
            // INIT
            index = 0;
            inProgress = true;

            // CHOOSE Path
            if (!initialDialogue)
            {
                type = LevelOneDialogue.Initial;
                dialogue = initialDialogueSentences;
            }
            else
            {
                if (resources.Wood >= 5 && resources.Stone >= 5)
                {
                    type = LevelOneDialogue.Complete;
                    dialogue = completedDialogueSentences;
                }
                else
                {
                    type = LevelOneDialogue.NotEnough;
                    dialogue = notEnoughDialogueSentences;
                }
            }

            // START
            canvas.SetActive(true);
            NextSentence();
        }
    }

    public void NextSentence()
    {
        if (index >= dialogue.Length)
        {
            StopDialogue();
        }
        else
        {
            dialogueContainer.text = dialogue[index];
            index++;
        }
    }

    public void StopDialogue()
    {
        canvas.SetActive(false);
        inProgress = false;

        if (type == LevelOneDialogue.Complete)
        {
            Debug.Log("Go To Next Level");
        }
        else if (type == LevelOneDialogue.Initial)
        {
            initialDialogue = true;
        }
    }
}
