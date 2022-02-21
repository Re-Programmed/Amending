using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cards;

#pragma warning disable

public class CardTray : MonoBehaviour
{
    public GameObject card;
    public GameObject[] Cards;

    bool hovered = false;

    [SerializeField]
    GameObject Deck;

    [SerializeField]
    DialogueSequence ds;

    [SerializeField]
    SpriteRenderer sr;

    public void OnMouseEnter()
    {
        hovered = true;
    }

    public void OnMouseExit()
    {
        hovered = false;
    }

    private void Start()
    {
        card = Cards[Random.Range(0, Cards.Length)];
        sr.sprite = card.GetComponent<InventoryCard>().CardSP.sprite;
    }

    public void Update()
    {
        if (hovered && TurnManager.GetIsPlayersTurn())
        {
            HoverDisplay.HoverAt(transform.position + new Vector3(0f, 3f, 0f), card.GetComponent<InventoryCard>().card.Title, "", card.GetComponent<InventoryCard>().card.Desc);
            if(Input.GetMouseButtonDown(0))
            {
                if (Deck.GetComponentsInChildren<InventoryCard>().Length < 8)
                {
                    Instantiate(card, Deck.transform);

                    TurnManager.PlayerMoveDrawCard(ds);

                    card = Cards[Random.Range(0, Cards.Length)];
                    sr.sprite = card.GetComponent<InventoryCard>().CardSP.sprite;
                }
            }
        }
    }
}
