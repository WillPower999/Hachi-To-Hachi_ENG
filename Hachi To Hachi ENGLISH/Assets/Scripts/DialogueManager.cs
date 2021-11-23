using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Canvas dialogueCanvas;
    public Text characterName;
    public Text dialogueText;

    private Queue<string> sentences;

    private bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (isTalking == true)
        {
            dialogueCanvas.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                DisplayNextSentence();
            }
        }
        else
        {
            dialogueCanvas.enabled = false;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Cursor.lockState = CursorLockMode.Confined;

        isTalking = true;
        characterName.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        isTalking = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
