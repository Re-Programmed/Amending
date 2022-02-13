using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        public static EnemyAI INSTANCE;

        public void Awake()
        {
            if(INSTANCE != null){ Destroy(this); return; }
            INSTANCE = this;
        }

        [SerializeField]
        List<Card> cards = new List<Card>();

        [SerializeField]
        Card[] Drawables;

        [SerializeField]
        DialogueSequence ds;

        public static void ChooseAttackOrDefense(EnemyBrainData data)
        {
            bool defend = false;
            if(data.LastMoveWasAttack)
            {
                if(Random.Range(0, 100) < 80)
                {
                    defend = true;
                }
            }
        }

        public static void DrawCard()
        {
            INSTANCE.cards.Add(INSTANCE.Drawables[Random.Range(0, INSTANCE.Drawables.Length)]);

            TurnManager.EnemyDrawCard(INSTANCE.ds);
        }

        public static void PlayTopCard()
        {
            TurnManager.INSTANCE.LastCardWasEnemy = true;
            if(INSTANCE.cards.Count < 2)
            {
                DrawCard();
                return;
            } 

            if(TurnManager.LastCardPlayed != null && TurnManager.LastCardPlayed is AttackCard && TurnManager.moves == 0 && Random.Range(0, 100) < 55)
            {
                Card currentWinner = null;
                int val = 0;

                if (TurnManager.LastCardPlayed is IAttackCard)
                {
                    foreach (Card c in INSTANCE.cards)
                    {
                        if (c is IAmendment)
                        {
                            int i = ((IAmendment)c).GetPowerForCard(TurnManager.LastCardPlayed);

                            if (val < i)
                            {
                                val = i;
                                currentWinner = c;
                            }
                        }
                    }
                }

                if (currentWinner != null)
                {
                    if (Random.Range(0, 100) < 77)
                    {
                        if (val > 4)
                        {
                            HealthManager.AttackPlayer(((IAmendment)currentWinner).GetPowerForCard(TurnManager.LastCardPlayed));

                            INSTANCE.cards.Remove(currentWinner);

                            TurnManager.EnemyMove(currentWinner);
                            return;
                        }
                    }
                    else
                    {
                        HealthManager.AttackPlayer(((IAmendment)currentWinner).GetPowerForCard(TurnManager.LastCardPlayed));

                        INSTANCE.cards.Remove(currentWinner);

                        TurnManager.EnemyMove(currentWinner);
                        return;
                    }
                }
            }

            if (INSTANCE.cards.Count < 5)
            {
                if (Random.Range(0, 100) < 45)
                {
                    DrawCard();
                    return;
                }
            }

            if (INSTANCE.cards[0] is IAttackCard)
            {
                IAttackCard attkcard = INSTANCE.cards[0] as IAttackCard;

                HealthManager.AttackPlayer(attkcard.GetAttackingPower());

                INSTANCE.cards.Remove(INSTANCE.cards[0]);

                TurnManager.EnemyMove(INSTANCE.cards[0]);
                return;
            }

            DrawCard();


        }
    }

}