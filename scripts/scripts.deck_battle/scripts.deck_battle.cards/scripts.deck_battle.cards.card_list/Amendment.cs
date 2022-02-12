using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "New Amendment", menuName = "ScriptableObjects/Cards/Amendment", order = 1)]
    public class Amendment : Card, IAmendment
    {
        public AmendmentDefenses[] defenses;

        public AmendmentDefenses[] GetDefensePowers()
        {
            return defenses;
        }

        public int GetPowerForCard(Card card)
        {
            foreach(AmendmentDefenses d in defenses)
            {
                if(d.GetCard().Title == card.Title)
                {
                    return d.GetPower();
                }
            }

            return 0;
        }
    }
}