using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    public List<SCard> EnemyDeck, PlayerDeck, 
                       EnemyHand, PlayerHand, 
                       EnemyField, PlayerField;

    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();
        EnemyHand = new List<SCard>();
        PlayerHand = new List<SCard>();
        EnemyField = new List<SCard>();
        PlayerField = new List<SCard>();
    }

    List<SCard> GiveDeckCard()
    {
        List<SCard> list = new List<SCard>();
        for (int i = 0; i < 10; i++)
            list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
        return list;
    }
}

public class GameManagerScript : MonoBehaviour
{
    public Game CurrentGame;
    public Transform EnemyHand, PlayerHand;
    public GameObject CardPref;
    int Turn, TurnTime = 30;
    public TextMeshProUGUI TurnTimeTxt;
    public Button EndTurnBtn;
    public bool IsPlayerTurn
    {
        get
        {
            return Turn % 2 == 0;
        }
    }

    void Start()
    {
        Turn = 0;
        CurrentGame = new Game();
        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand);
        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand);
        StartCoroutine(TurnFunc());
    }

    void GiveHandCards(List<SCard> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 4)
            GiveCardToHand(deck, hand);
    }
    void GiveCardToHand(List<SCard> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;
        SCard card = deck[0];
        GameObject cardGO = Instantiate(CardPref, hand, false);
        if (hand == EnemyHand)
            cardGO.GetComponent<CardInfoScript>().HideCardInfo(card);
        else
            cardGO.GetComponent<CardInfoScript>().ShowCardInfo(card);

        deck.RemoveAt(0);
    }

    IEnumerator TurnFunc()
    {
        TurnTime = 30;
        TurnTimeTxt.text = TurnTime.ToString();
        if (IsPlayerTurn)
        {
            while(TurnTime-- > 0)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }

        }
        else
        {
            while(TurnTime-- > 25)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        ChangeTurn();
    }

    public void ChangeTurn()
    {
        StopAllCoroutines();
        Turn++;
        EndTurnBtn.interactable = IsPlayerTurn;
        if(IsPlayerTurn)
            GivenNewCards();
        StartCoroutine(TurnFunc());
    }

    void GivenNewCards()
    {
        GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
        GiveCardToHand(CurrentGame.PlayerDeck, PlayerHand);
    }
}
