using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceEffector : MonoBehaviour
{
    [SerializeField]
    GameObject player; 

    [SerializeField]
    AudioSource audioSource;

    void Update()
    {
        if(Vector2.Distance(player.transform.position, transform.position) < 10f)
        {
            audioSource.volume = 10f - Vector2.Distance(player.transform.position, transform.position);
        }
    }
}
