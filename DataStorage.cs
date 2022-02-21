using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EmotionDatabase;

public class DataStorage : MonoBehaviour
{
    public static DataStorage INSTANCE;

    public BattleScenario battleScenario;

    public void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartBattle(BattleScenario bs)
    {
        battleScenario = bs;
        SceneManager.LoadSceneAsync(0);
    }
}

[System.Serializable]
public class BattleScenario
{
    public string BattleTopic;
    public GameObject[] AvailableCards;
    public Cards.Card[] EnemyCards;

    public CurrentSprite EnemySprite;
}