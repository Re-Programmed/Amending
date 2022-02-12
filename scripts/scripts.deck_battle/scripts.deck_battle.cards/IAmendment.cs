using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public interface IAmendment
    {
        AmendmentDefenses[] GetDefensePowers();
        int GetPowerForCard(Card card);
    }
}