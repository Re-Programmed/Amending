using Cards;
using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    static bool isPlayersTurn = true;

    public static int moves { get; private set; } = 0;

    public static Card LastCardPlayed;

    public static bool GetIsPlayersTurn()
    {
        return isPlayersTurn;
    }

    public static void PlayerMove(Card card)
    {
        LastCardPlayed = card;
        moves++;

        if(moves == 2)
        {
            isPlayersTurn = false;
            moves = 0;
            EnemyAI.PlayTopCard();
        }
    }

    public static IEnumerator EnemyPlay()
    {
        yield return new WaitForSeconds(1f);
        EnemyAI.PlayTopCard();
    }

    public static void EnemyMove(Card card)
    {
        LastCardPlayed = card;
        moves++;

        if(moves == 2)
        {
            isPlayersTurn = true;
            moves = 0;
        }
        else
        {
            EnemyAI.PlayTopCard();
        }
    }
}
