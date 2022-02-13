using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionDatabase : MonoBehaviour
{
    public static EmotionDatabase INSTANCE;

    public void Awake()
    {
        if (INSTANCE != null) { Destroy(this);return; }
        INSTANCE = this;
    }

    public enum CurrentSprite
    {
        ElvisGuy,
        FancyCitizen,
        HipScientist,
        Judge,
        Prosecution,
        Reporter
    }

    public CurrentSprite PlayerSprite;
    public CurrentSprite EnemySprite;

    public Emotion[] emotions;

    public void SetCharacterEmotion(string emotionValue, CurrentSprite sprite, SpriteRenderer spriteRenderer)
    {
        foreach (Emotion e in emotions)
        {
            if(emotionValue == e.value)
            {
                if(sprite == e.SpriteApply)
                {
                    spriteRenderer.sprite = e.sprite;
                    return;
                }
            }
        }
    }
}

[System.Serializable]
public class Emotion
{
    public EmotionDatabase.CurrentSprite SpriteApply;
    public Sprite sprite;
    public string value;
}