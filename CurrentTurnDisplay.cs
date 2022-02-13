using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTurnDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Enemy;

    Transform target;

    [SerializeField]
    float above = 2f;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(target.transform.position.x * 1.1f, target.transform.position.y + above), Time.deltaTime * 10f);
    }

    public void GoToPlayer()
    {
        target = Player.transform;
    }

    public void GoToEnemy()
    {
        target = Enemy.transform;
    }
}
