using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    public interface IAttackCard
    {
        void Attack();

        int GetAttackingPower();
    }
}