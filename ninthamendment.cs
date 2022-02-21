using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "9th Amendment", menuName = "ScriptableObjects/Cards/9thAmendment", order = 1)]
    public class ninthamendment : Card, IAmendment
    {
        Card lastgottencard;
        public AmendmentDefenses[] GetDefensePowers()
        {
            AmendmentDefenses[] d = { new AmendmentDefenses(lastgottencard, 30, this.dialogue) };
            return d;
        }

        public int GetPowerForCard(Card card)
        {
            lastgottencard = card;
            return 20;
        }
    }

}


