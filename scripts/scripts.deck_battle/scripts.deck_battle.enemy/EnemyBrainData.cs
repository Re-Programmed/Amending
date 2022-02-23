using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrainData : MonoBehaviour
{
    public readonly bool LastMoveWasAttack;

    public EnemyBrainData(bool LastMoveWasAttack)
    {
        this.LastMoveWasAttack = LastMoveWasAttack;
    }
   
}
