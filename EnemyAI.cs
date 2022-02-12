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

        public static void PlayTopCard()
        {
            if(INSTANCE.cards[0] is IAttackCard)
            {
                IAttackCard attkcard = INSTANCE.cards[0] as IAttackCard;

                HealthManager.AttackPlayer(attkcard.GetAttackingPower());
            }

            TurnManager.EnemyMove(INSTANCE.cards[0]);
        }
    }

}