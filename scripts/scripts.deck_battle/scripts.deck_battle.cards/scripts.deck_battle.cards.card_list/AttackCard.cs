using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "New Attack", menuName = "ScriptableObjects/Cards/Attack", order = 2)]
    public class AttackCard : Card, IAttackCard
    {
        [SerializeField]
        protected int AttkPower = 5;

        public void Attack()
        {
            HealthManager.AttackEnemy(GetAttackingPower());
        }

        public int GetAttackingPower()
        {
            return AttkPower;
        }

    }
}
