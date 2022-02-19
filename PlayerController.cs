using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private GameObject sr;

    [SerializeField]
    Animator anim;

    public bool locked = false;

    private void Update()
    {
        if(locked)
        {
            anim.SetBool("walking", false);
            return;
        }

        anim.SetBool("walking", Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * -speed * Time.deltaTime);
            sr.transform.rotation = Quaternion.Euler(0, 180, 0);
            sr.transform.localPosition = new Vector3(-1.48f, 0, 0);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            sr.transform.rotation = Quaternion.Euler(0, 0, 0);
            sr.transform.localPosition = Vector3.zero;
        }
    }
}
