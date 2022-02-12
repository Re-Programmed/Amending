using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "New Amendment", menuName = "ScriptableObjects/Cards/Amendment", order = 1)]
    public class Amendment : Card, IAmendment
    {
        public void PlayCard()
        {

        }
    }
}