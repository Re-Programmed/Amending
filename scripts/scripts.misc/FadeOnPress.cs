using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

#pragma warning disable

public class FadeOnPress : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI title, controls, description;

    [SerializeField]
    Image bg;

    float alpha = 1f;

    [SerializeField]
    Transform player;

    Color initcolor = new Color(0f, 0f, 0f, 143f);

    [SerializeField]
    AudioSource audio;

    private void Update()
    {
        Color c = new Color(initcolor.r, initcolor.g, initcolor.b, -(player.position.x - 4f)/6f);
        if(c.a < 0)
        {
            c.a = 0;
        }
        bg.color = c;

        c = Color.white;
        c.a = -(player.position.x - 4f) / 6f;

        if (c.a < 0)
        {
            c.a = 0;
        }
        title.color = c;
        controls.color = c;
        description.color = c;

        audio.volume = c.a;
    }
}
