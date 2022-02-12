using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "ScriptableObjects/Cards/Attack", order = 2)]
public class AttackCard : Card, IAttackCard
{
    public void Attack()
    {

    }

    public int GetAttackingPower()
    {
        return 5;
    }

}
