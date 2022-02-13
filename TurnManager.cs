using Cards;
using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    CameraController cameraController;

    [SerializeField]
    public CardDeckManager cdm;

    static bool isPlayersTurn = true;

    public static int moves { get; private set; } = 0;

    public static Card LastCardPlayed;

    public static TurnManager INSTANCE;

    public SpeechBubble player_sb;

    [SerializeField]
    private CurrentTurnDisplay display;

    public void Awake()
    {
        if (INSTANCE != null) { Destroy(this); return; }
        INSTANCE = this;
    }

    private void Start()
    {
        display.GoToPlayer();
    }

    public static bool GetIsPlayersTurn()
    {
        return isPlayersTurn;
    }

    public static void ContinuePPlay(bool on)
    {
        if(!on)
        {
            if(LastCardPlayed.retaliation.dialogues.Count == 0)
            {
                FinishRetaliation(false);
            }
            else
            {
                INSTANCE.player_sb.statusChanged -= ContinuePPlay;
                INSTANCE.player_sb.statusChanged += FinishRetaliation;
                INSTANCE.cameraController.EnemyActionShot();
                INSTANCE.StartCoroutine(INSTANCE.StartRetaliation());
            }
        }
    }

    public IEnumerator StartRetaliation()
    {
        yield return new WaitForSeconds(0.2f);
        player_sb.Say(LastCardPlayed.retaliation);
    }

    public static void FinishRetaliation(bool on)
    {
        if(!on)
        {
            INSTANCE.player_sb.statusChanged -= FinishRetaliation;
            INSTANCE.StartCoroutine(INSTANCE.ContPPlay());
        }
    }

    public IEnumerator ContPPlay()
    {
        INSTANCE.cdm.FadeUpBG();
        if (moves == 2)
        {
            INSTANCE.display.GoToEnemy();
            INSTANCE.cdm.FadeAwayBG();
            isPlayersTurn = false;
            moves = 0;
            INSTANCE.StartEnemyPlay();
            cameraController.DefaultShot();
            INSTANCE.player_sb.statusChanged -= ContinuePPlay;
            yield break;
        }
        cameraController.DefaultShot();

        yield return new WaitForSeconds(0.5f);
        isPlayersTurn = true;
        INSTANCE.player_sb.statusChanged -= ContinuePPlay;
    }

    public static void PlayerMove(Card card)
    {
        Card lp = LastCardPlayed;
        LastCardPlayed = card;
        moves++;

        isPlayersTurn = false;
        HoverDisplay.INSTANCE.children.SetActive(false);
        HoverDisplay.INSTANCE.GetComponent<SpriteRenderer>().enabled = false;

        INSTANCE.cdm.FadeAwayBG();
        INSTANCE.player_sb.statusChanged += ContinuePPlay;

        INSTANCE.cameraController.PlayerActionShot();

        if(card is Amendment)
        {
            INSTANCE.player_sb.Say(((Amendment)card).GetDialogue(lp));
        }
        else
        {
            INSTANCE.player_sb.Say(card.dialogue);
        }
    }

    public void StartEnemyPlay()
    {
        HoverDisplay.INSTANCE.children.SetActive(false);
        HoverDisplay.INSTANCE.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(EnemyPlay());
    }

    public IEnumerator EnemyPlay()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        EnemyAI.PlayTopCard();
    }

    public static void EnemyMove(Card card)
    {
        LastCardPlayed = card;
        moves++;

        if(moves == 2)
        {
            INSTANCE.display.GoToPlayer();
            INSTANCE.cdm.FadeUpBG();
            isPlayersTurn = true;
            moves = 0;
        }
        else
        {
            INSTANCE.StartEnemyPlay();
        }
    }
}
