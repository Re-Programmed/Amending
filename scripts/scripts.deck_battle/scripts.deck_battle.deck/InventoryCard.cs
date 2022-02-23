using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Cards
{
    public class InventoryCard : MonoBehaviour
    {
        [Header("Assign Objects")]
        [SerializeField]
        protected TextMeshPro PowerLevelDisplay;
        [SerializeField]
        public SpriteRenderer Overlay;
        [SerializeField]
        public SpriteRenderer CardSP;

        [Header("Card")]
        [SerializeField]
        public Card card;

        [Header("Hover Data")]
        [SerializeField]
        protected Vector2 hoverPosition;

        bool hovered = false;

        private Vector2 startScale;

   
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(new Vector2(transform.position.x + hoverPosition.x, transform.position.y + hoverPosition.y), 0.5f);
        }

        private void Awake()
        {
            startScale = transform.localScale;
        }

        private void Update()
        {
            if (card is IAmendment)
            {
                if (TurnManager.moves != 0)
                {
                    CardSP.color = Color.gray;
                }
                else{
                    CardSP.color = Color.white;
                }
            }

            if (hovered)
            {
                hovered = HoverDisplay.hoveredCard == this;

                transform.localScale = Vector2.Lerp(transform.localScale, startScale * 1.25f, Time.deltaTime * 7f);
                Overlay.sortingLayerName = "card_hover";
                CardSP.sortingLayerName = "card_hover";

                if(TurnManager.GetIsPlayersTurn())
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (card is IAttackCard)
                        {
                            TurnManager.INSTANCE.LastCardWasEnemy = false;
                            IAttackCard attkcard = card as IAttackCard;

                            attkcard.Attack();

                            TurnManager.PlayerMove(card);

                            Destroy(gameObject);
                        }

                        if(card is IAmendment)
                        {
                            IAmendment amendment = card as IAmendment;

                            if(TurnManager.moves == 0)
                            {
                                if(TurnManager.INSTANCE.LastCardWasEnemy)
                                {
                                    TurnManager.INSTANCE.LastCardWasEnemy = false;
                                    int dmg = amendment.GetPowerForCard(TurnManager.LastCardPlayed);
                                    if (card.boostedStage == TurnManager.GetCurrentStageType())
                                    {
                                        dmg += card.boostedPower;
                                    }
                                    HealthManager.AttackEnemy(dmg);
                                    TurnManager.PlayerMove(card);

                                    Destroy(gameObject);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                transform.localScale = Vector2.Lerp(transform.localScale, startScale, Time.deltaTime * 7f);
                Overlay.sortingLayerName = "card_normal";
                CardSP.sortingLayerName = "card_normal";
            }
        }

        public void onHover()
        {
            hovered = true;
            string stats = "";

            if (card is IAttackCard)
            {
                IAttackCard attkcard = card as IAttackCard;

                stats = $"<color=red>Attack Card\n<color=green>Power: {attkcard.GetAttackingPower()}";
            }

            if (card is IAmendment)
            {
                IAmendment attkcard = card as IAmendment;

                stats = $"<color=yellow>Amendment";
            }

            HoverDisplay.HoverAt(new Vector2(transform.position.x + hoverPosition.x, transform.position.y + hoverPosition.y), card.Title, stats, card.Desc, this);
        }


        public void OnMouseEnter()
        {
            onHover();
        }
    }
}
