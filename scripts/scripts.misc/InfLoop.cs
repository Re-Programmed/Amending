using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class InfLoop : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    [SerializeField]
    Vector2 pos;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.one);

        Gizmos.DrawWireSphere(pos, 1f);
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < 1f)
        {
            Camera.main.gameObject.GetComponent<GameplayCamera>().moveDistance = 0.5f;
            player.transform.position = pos;
        }
    }
}
