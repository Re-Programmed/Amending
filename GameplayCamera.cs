using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCamera : MonoBehaviour
{
    [SerializeField]
    GameObject Follow;

    [SerializeField]
    float moveDistance;

    Vector2 LerpPosition;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position, new Vector3(moveDistance, moveDistance, moveDistance));
    }

    private void Start()
    {
        LerpPosition = Follow.transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(LerpPosition.x, LerpPosition.y, -10), 8f * Time.deltaTime);
        if(Follow.transform.position.x > transform.position.x + moveDistance)
        {
            LerpPosition = Follow.transform.position;
        }
        if (Follow.transform.position.x < transform.position.x - moveDistance)
        {
            LerpPosition = Follow.transform.position;
        }
    }
}
