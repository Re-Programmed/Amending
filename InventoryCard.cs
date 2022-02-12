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
        protected SpriteRenderer Overlay;

        [Header("Card")]
        [SerializeField]
        protected Card card;

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
            if (hovered)
            {
                hovered = HoverDisplay.hoveredCard == this;

                transform.localScale = Vector2.Lerp(transform.localScale, startScale * 1.25f, Time.deltaTime * 4f);
            }
            else
            {
                transform.localScale = Vector2.Lerp(transform.localScale, startScale, Time.deltaTime * 4f);
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

            HoverDisplay.HoverAt(new Vector2(transform.position.x + hoverPosition.x, transform.position.y + hoverPosition.y), card.Title, stats, card.Desc, this);
        }


        public void OnMouseEnter()
        {
            onHover();
        }
    }
}
