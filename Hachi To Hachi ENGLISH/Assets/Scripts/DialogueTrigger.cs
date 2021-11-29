using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueTrigger : MonoBehaviour
{
    public TextAsset convo;
    private Queue<string> dialogue = new Queue<string>();
    public void TriggerDialogue()
    {
        dialogue.Clear();
        string txt = convo.text;

        string[] lines = txt.Split(System.Environment.NewLine.ToCharArray()); // Split dialogue lines by newline

        foreach (string line in lines) // for every line of dialogue
        {
            if (!string.IsNullOrEmpty(line))// ignore empty lines of dialogue
            {
                /*if (line.StartsWith("[")) // e.g [NAME=Michael] Hello, my name is Michael
                {
                    string special = line.Substring(0, line.IndexOf(']') + 1); // special = [NAME=Michael]
                    string curr = line.Substring(line.IndexOf(']') + 1); // curr = Hello, ...
                    dialogue.Enqueue(special); // adds to the dialogue to be printed
                    dialogue.Enqueue(curr);
                }
                else
                {*/
                    dialogue.Enqueue(line); // adds to the dialogue to be printed
                //}
            }
        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
