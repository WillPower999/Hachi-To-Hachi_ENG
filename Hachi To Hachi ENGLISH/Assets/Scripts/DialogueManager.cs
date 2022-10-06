using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
            Debug.Log("isTalking = " + isTalking);
            dialogueCanvas.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("key hit");
                DisplayNextSentence();
            }
        }
        else
        {
            Debug.Log("isTalking = " + isTalking);
            dialogueCanvas.enabled = false;
        }
    }

    public void StartDialogue(Queue<string> dialogue)
    {
        Debug.Log("dialogue started");
        Cursor.lockState = CursorLockMode.Confined;

        isTalking = true;
        sentences.Clear();
        foreach (string sentence in dialogue)
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
        if (sentence.StartsWith("["))
        {
            characterName.text = sentence.Substring(1, sentence.IndexOf(']') - 1);
            sentence = sentence.Substring(sentence.IndexOf(']') + 1);
        }
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        isTalking = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
