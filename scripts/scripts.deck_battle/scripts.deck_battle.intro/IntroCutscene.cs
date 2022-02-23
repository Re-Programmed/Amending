using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable

public class IntroCutscene : MonoBehaviour
{
    [SerializeField]
    Camera cam_main;

    [SerializeField]
    GameObject deck;

    [SerializeField]
    GameObject x3;

    int x = 0;

    private void Update()
    {
        if(x < 8)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 1.5f * Time.deltaTime * (Input.GetMouseButton(0) ? 3f : 1f));

            x3.SetActive(Input.GetMouseButton(0));

            if(transform.position.x > -60)
            {
                transform.position = new Vector3(-120, transform.position.y, transform.position.z);
                x++;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, cam_main.transform.position, 1.5f * Time.deltaTime * (Input.GetMouseButton(0) ? 3f : 1f));

            x3.SetActive(Input.GetMouseButton(0));

            if (Vector3.Distance(transform.position, cam_main.transform.position) < 0.2f)
            {
                cam_main.gameObject.SetActive(true);
                gameObject.SetActive(false);
                deck.SetActive(true);
            }
        }
    }
}
