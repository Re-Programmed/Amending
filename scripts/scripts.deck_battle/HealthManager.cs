using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager
{
    public static int PlayerHealth { get; private set; } = 100;
    public static int EnemyHealth { get; private set; } = 100;

    public static void AttackPlayer(int HP)
    {
        PlayerHealth -= HP;
        EnemyHealth += HP;

        HPSlider.SetValue(EnemyHealth);
    }

    public static void AttackEnemy(int HP)
    {
        EnemyHealth -= HP;
        PlayerHealth += HP;

        HPSlider.SetValue(EnemyHealth);
    }

    public static void ResetHP()
    {
        EnemyHealth = 100;
        PlayerHealth = 100;
    }
}
