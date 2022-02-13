using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSequence
{
    public List<Dialogue> dialogues = new List<Dialogue>();

    int i = 0;

    public void SetI(int i)
    {
        this.i = i;
    }

    public Dialogue GetNextDialogue()
    {
        Debug.Log("Next Dialogue: " + i);
        i++;
        if(i - 1 >= dialogues.Count)
        {
            i = 0;
            return null;
        }

        return dialogues[i - 1];
    }
}

[System.Serializable]
public class Dialogue
{
    public Dialogue()
    {

    }

    public Dialogue(Saying WhoIsSaying, string text)
    {
        this.WhoIsSaying = WhoIsSaying;
        this.text = text;
    }

    public enum Saying
    {
        Player,
        Enemy
    }

    public Saying WhoIsSaying;

    public string text;
}