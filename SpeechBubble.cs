using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField]
    TextMeshPro text;

    [SerializeField]
    GameObject BG;

    bool open = false;

    public delegate void StatusChanged(bool on);
    public StatusChanged statusChanged;

    DialogueSequence ds;

    int cooldown = 0;

    public void Say(DialogueSequence ds)
    {
        this.ds = ds;
        ds.SetI(0);
        this.text.text = ds.GetNextDialogue().text;

        this.text.gameObject.SetActive(true);

        BG.SetActive(true);

        statusChanged?.Invoke(true);

        open = true;

        cooldown = 20;
    }

    private void Update()
    {
        cooldown--;

        if (cooldown > 0) { return; }
        if(Input.GetMouseButtonDown(0))
        {
            if(open)
            {
                Dialogue d = ds.GetNextDialogue();
                if (d == null)
                {
                    text.gameObject.SetActive(false);
                    statusChanged?.Invoke(false);
                    BG.SetActive(false);
                    open = false;
                }
                else
                {
                    this.text.text = d.text;

                    this.text.gameObject.SetActive(true);
                    BG.SetActive(true);
                }
            }
        }
    }


}
