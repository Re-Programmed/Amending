using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

namespace Cards
{
    [System.Serializable]
    public class AmendmentDefenses
    {
        [SerializeField]
        private Card card;
        [SerializeField]
        private int power;

        [SerializeField]
        public DialogueSequence dialogue;

        public Card GetCard()
        {
            return card;
        }

        public int GetPower()
        {
            return power;
        }
    }
}