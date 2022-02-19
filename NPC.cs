using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    DialogueSequence ds_inrange;

    [SerializeField]
    PlayerController player;

    [SerializeField]
    SpeechBubble speechBubble;

    EmotionDatabase.CurrentSprite sprite;

    bool inrangetalked = false;

    [SerializeField]
    BattleScenario scenario;

    void Update()
    {
        InRange();
    }

    void InRange()
    {
        if (!Input.GetKeyDown(KeyCode.E)) { return; }
        if (Vector2.Distance(player.transform.position, transform.position) < 2f)
        {
            if (inrangetalked) { return; }
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

    void UnlockPlayer(bool on)
    {
        if (on) { return; }
        player.locked = false;
        speechBubble.statusChanged -= UnlockPlayer;

        DataStorage.INSTANCE.StartBattle(scenario);
    }
}
