using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour
{
    bool hovered = false;

    [SerializeField]
    GameObject[] Cards;

    [SerializeField]
    GameObject Deck;

    [SerializeField]
    DialogueSequence ds;

    public void OnMouseEnter()
    {
        hovered = true;
    }

    public void OnMouseExit()
    {
        hovered = false;
    }

    public void Update()
    {
        if (!TurnManager.GetIsPlayersTurn()) { return; }
        if(hovered)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(Deck.GetComponentsInChildren<InventoryCard>().Length < 8)
                {
                    Instantiate(Cards[Random.Range(0, Cards.Length)], Deck.transform);

                    TurnManager.PlayerMoveDrawCard(ds);
                }
            }
        }
    }

}
