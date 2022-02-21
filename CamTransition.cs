using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class CamTransition : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    Color transitionEndColor;

    [SerializeField]
    Color startColor;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, Vector3.one * 5f);
    }

    private void Update()
    {
        if(Vector2.Distance(player.transform.position, transform.position) < 5f)
        {
            Camera.main.backgroundColor = Color.Lerp(startColor, transitionEndColor, (player.transform.position.x - transform.position.x + 2.5f)/5f);
        }
    }
}
