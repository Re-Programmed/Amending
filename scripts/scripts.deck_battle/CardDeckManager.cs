using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public class CardDeckManager : MonoBehaviour
    {
        public List<Card> cards { get; private set; } = new List<Card>();

        public void AddCardToDeck(Card card)
        {
            cards.Add(card);
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}
