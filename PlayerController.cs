using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private GameObject sr;

    [SerializeField]
    Animator anim;

    [SerializeField]
    ParticleSystem ps;

    public bool locked = false;

    private void Update()
    {
        if(locked)
        {
            anim.SetBool("walking", false);
            return;
        }

        anim.SetBool("walking", Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));

        bool playps = false;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * -speed * Time.deltaTime);
            sr.transform.rotation = Quaternion.Euler(0, 180, 0);
            sr.transform.localPosition = new Vector3(-1.48f, 0, 0);
            ps.startSpeed = -2;
            playps = true;
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            sr.transform.rotation = Quaternion.Euler(0, 0, 0);
            sr.transform.localPosition = Vector3.zero;
            ps.startSpeed = 2;
            playps = true;
        }

        if(playps)
        {
            ps.enableEmission = true;
        }
        else
        {
            ps.enableEmission = false;
        }
    }
}
