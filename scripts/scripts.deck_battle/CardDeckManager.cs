using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class CardDeckManager : MonoBehaviour
    {
        public List<Card> cards { get; private set; } = new List<Card>();

        Vector2 targetScale;

        public void AddCardToDeck(Card card)
        {
            cards.Add(card);
        }

        private void Awake()
        {
            targetScale = transform.localScale;
        }

        void Start()
        {
        }


        void Update()
        {
            transform.localScale = Vector2.Lerp(transform.localScale, targetScale, Time.deltaTime * 8f);
        }


        public void FadeUpBG()
        {
            targetScale = Vector2.one;
        }

        public void FadeAwayBG()
        {
            targetScale = new Vector2(1f, 0f);
        }
    }
}
