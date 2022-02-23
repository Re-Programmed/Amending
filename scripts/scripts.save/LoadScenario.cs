using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class LoadScenario : MonoBehaviour
{
    [SerializeField]
    SpeechBubble sb;

    [SerializeField]
    SpriteRenderer enemy;

    [SerializeField]
    CardPile cp;

    [SerializeField]
    CardTray tray;

    private void Start()
    {
        HealthManager.ResetHP();
        TurnManager.isPlayersTurn = true;
        TurnManager.LastCardPlayed = null;
        TurnManager.moves = 0;
        if(DataStorage.INSTANCE != null)
        {
            sb.issue = DataStorage.INSTANCE.battleScenario.BattleTopic;
            EmotionDatabase.INSTANCE.EnemySprite = DataStorage.INSTANCE.battleScenario.EnemySprite;
            sb.defaultEEmotion = EmotionDatabase.INSTANCE.GetEmotion("idle", DataStorage.INSTANCE.battleScenario.EnemySprite);
            enemy.sprite = sb.defaultEEmotion;
            Enemy.EnemyAI.INSTANCE.Drawables = DataStorage.INSTANCE.battleScenario.EnemyCards;

            cp.Cards = DataStorage.INSTANCE.battleScenario.AvailableCards;
            tray.Cards = DataStorage.INSTANCE.battleScenario.AvailableCards;
        }
    }

    public void BackToMainScene()
    {
        StartCoroutine(BackToScene());
    }

    public void BackToMainSceneWin()
    {
        DataStorage.savedata.interactions.Add(DataStorage.INSTANCE.battleScenario.id);

        SaveData.Save(DataStorage.savedata);

        BackToMainScene();
    }

    IEnumerator BackToScene()
    {
        yield return new WaitForSeconds(0.05f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
