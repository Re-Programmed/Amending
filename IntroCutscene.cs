using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    [SerializeField]
    Camera cam_main;

    [SerializeField]
    GameObject deck;

    int x = 0;

    private void Update()
    {
        if(x < 8)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 1.5f * Time.deltaTime);

            if(transform.position.x > -60)
            {
                transform.position = new Vector3(-120, transform.position.y, transform.position.z);
                x++;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, cam_main.transform.position, 1.5f * Time.deltaTime);

            if (Vector3.Distance(transform.position, cam_main.transform.position) < 0.2f)
            {
                cam_main.gameObject.SetActive(true);
                gameObject.SetActive(false);
                deck.SetActive(true);
            }
        }
    }
}
