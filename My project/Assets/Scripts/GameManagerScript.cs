using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    public List<SCard> EnemyDeck, PlayerDeck;

    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();
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
    public Transform EnemyHand, PlayerHand,
                     EnemyField, PlayerField;
    public GameObject CardPref;
    int Turn, TurnTime = 30;
    public TextMeshProUGUI TurnTimeTxt;
    public Button EndTurnBtn;

    public List<CardInfoScript> PlayerHandCards = new List<CardInfoScript>(),
                                EnemyHandCards = new List<CardInfoScript>(),
                                PlayerFieldCards = new List<CardInfoScript>(),
                                EnemyFieldCards = new List<CardInfoScript>();
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
        {
            cardGO.GetComponent<CardInfoScript>().HideCardInfo(card);
            EnemyHandCards.Add(cardGO.GetComponent<CardInfoScript>());
        }
        else
        {
            cardGO.GetComponent<CardInfoScript>().ShowCardInfo(card, true);
            PlayerHandCards.Add(cardGO.GetComponent<CardInfoScript>());
            cardGO.GetComponent<AttackedCardScript>().enabled = false;
        }
            

        deck.RemoveAt(0);
    }

    IEnumerator TurnFunc()
    {
        TurnTime = 30;
        TurnTimeTxt.text = TurnTime.ToString();
        if (IsPlayerTurn)
        {
            foreach (var card in PlayerFieldCards)
                card.SelfCard.ChangeAttackState(true);
            while(TurnTime-- > 0)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }

        }
        else
        {
            foreach (var card in EnemyFieldCards)
                card.SelfCard.ChangeAttackState(true);
            while (TurnTime-- > 25)
            {
                TurnTimeTxt.text = TurnTime.ToString();
                yield return new WaitForSeconds(1);
            }

            if (EnemyHandCards.Count > 0)
                EnemyTurn(EnemyHandCards);
        }
        ChangeTurn();
    }

    void EnemyTurn(List<CardInfoScript> cards)
    {
        int count = Random.Range(0, cards.Count + 1);
        for(int i=0; i < count; i++)
        {
            if (EnemyFieldCards.Count > 4)
                return;
            cards[0].ShowCardInfo(cards[0].SelfCard, false);
            cards[0].transform.SetParent(EnemyField);
            EnemyFieldCards.Add(cards[0]);
            EnemyHandCards.Remove(cards[0]);
        }
        foreach(var activeCard in EnemyFieldCards.FindAll(x=> x.SelfCard.CanAttack))
        {
            if (PlayerFieldCards.Count == 0)
                return;
            var enemy = PlayerFieldCards[Random.Range(0, PlayerFieldCards.Count)];
            CardsFight(activeCard, enemy);
            activeCard.SelfCard.ChangeAttackState(false);
            
        }
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

    public void CardsFight(CardInfoScript playerCard, CardInfoScript enemyCard)
    {
        enemyCard.SelfCard.GetDamage(playerCard.SelfCard.atk);

        if (!playerCard.SelfCard.IsAlive)
            DestroyCard(playerCard);
        else
            playerCard.RefreshData();

        if (!enemyCard.SelfCard.IsAlive)
            DestroyCard(enemyCard);
        else
            enemyCard.RefreshData();
    }

    void DestroyCard(CardInfoScript card)
    {
        card.GetComponent<CardMovementScript>().OnEndDrag(null);
        if (EnemyFieldCards.Exists(x => x == card))
            EnemyFieldCards.Remove(card);

        if (PlayerFieldCards.Exists(x => x == card))
            PlayerFieldCards.Remove(card);

        Destroy(card.gameObject);
    }
}
