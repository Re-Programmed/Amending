using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class NPC : MonoBehaviour
{
    [SerializeField]
    DialogueSequence ds_inrange;

    [SerializeField]
    DialogueSequence already_talked;

    [SerializeField]
    PlayerController player;

    [SerializeField]
    SpeechBubble speechBubble;

    EmotionDatabase.CurrentSprite sprite;

    bool inrangetalked = false;

    [SerializeField]
    BattleScenario scenario;

    [Header("ID")]
    [SerializeField]
    int id;

    void Update()
    {
        if(GetComponent<BoxCollider2D>() != null)
        {
            if(DataStorage.savedata.interactions.Contains(id))
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        InRange();
    }

    void InRange()
    {
        if (player.locked) { return; }
        if (!Input.GetKeyDown(KeyCode.E)) { return; }
        if (Vector2.Distance(player.transform.position, transform.position) < 2f)
        {
            if(DataStorage.savedata.interactions.Contains(id) || inrangetalked)
            {
                player.locked = true;
                EmotionDatabase.INSTANCE.EnemySprite = sprite; 
                speechBubble.defaultEEmotion = GetComponent<SpriteRenderer>().sprite;
                speechBubble.Enemy = GetComponent<SpriteRenderer>();
                inrangetalked = true;
                speechBubble.Say(already_talked);
                speechBubble.statusChanged += UnlockPlayer_NoBattle;
                return;
            }

            player.locked = true;
            EmotionDatabase.INSTANCE.EnemySprite = sprite;
            speechBubble.defaultEEmotion = GetComponent<SpriteRenderer>().sprite;
            inrangetalked = true;
            speechBubble.Enemy = GetComponent<SpriteRenderer>();
            speechBubble.Say(ds_inrange);
            speechBubble.statusChanged += UnlockPlayer;
        }
        else
        {
            inrangetalked = false;
        }
    }

    void UnlockPlayer_NoBattle(bool on)
    {
        if (on) { return; }
        player.locked = false;
        speechBubble.statusChanged -= UnlockPlayer_NoBattle;
    }

    void UnlockPlayer(bool on)
    {
        if (on) { return; }
        player.locked = false;
        speechBubble.statusChanged -= UnlockPlayer;

        DataStorage.INSTANCE.StartBattle(scenario);
    }
}
