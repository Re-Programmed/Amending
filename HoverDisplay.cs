using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cards;

#pragma warning disable

public class HoverDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro Title, Desc1, Desc2;

    [SerializeField]
    public GameObject children;

    private Vector2 location;

    public static HoverDisplay INSTANCE;

    public static InventoryCard hoveredCard { get; private set; }

    public void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, location, Time.deltaTime * 4f);
    }

    public static void HoverAt(Vector2 location, string title, string description1, string description2, InventoryCard c = null)
    {
        INSTANCE.children.SetActive(true);
        INSTANCE.GetComponent<SpriteRenderer>().enabled = true;

        INSTANCE.location = location;

        INSTANCE.Title.text = title;
        INSTANCE.Desc1.text = description1;
        INSTANCE.Desc2.text = description2;

        if(c != null)
        {
            hoveredCard = c;
        }
    }

}
