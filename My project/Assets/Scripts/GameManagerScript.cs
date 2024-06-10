//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class Game
//{
//    public List<SCard> EnemyDeck, PlayerDeck;

//    public Game()
//    {
//        EnemyDeck = GiveDeckCard();
//        PlayerDeck = GiveDeckCard();
//    }

//    List<SCard> GiveDeckCard()
//    {
//        List<SCard> list = new List<SCard>();
//        for (int i = 0; i < 10; i++)
//            list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
//        return list;
//    }
//}

//public class GameManagerScript : MonoBehaviour
//{
//    public static GameManagerScript Instance;
//    public Game CurrentGame;
//    public Transform EnemyHand, PlayerHand,
//                     EnemyField, PlayerField;
//    public GameObject CardPref;
//    int Turn, TurnTime = 30;
//    public TextMeshProUGUI TurnTimeTxt;
//    public Button EndTurnBtn;

//    public List<CardController> PlayerHandCards = new List<CardController>(),
//                                EnemyHandCards = new List<CardController>(),
//                                PlayerFieldCards = new List<CardController>(),
//                                EnemyFieldCards = new List<CardController>();

//    private void Awake() {
//        if (Instance == null)
//            Instance = this;
//    }
//    public bool IsPlayerTurn
//    {
//        get
//        {
//            return Turn % 2 == 0;
//        }
//    }

//    void Start()
//    {
//        Turn = 0;
//        CurrentGame = new Game();
//        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand);
//        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand);
//        StartCoroutine(TurnFunc());
//    }

//    void GiveHandCards(List<SCard> deck, Transform hand)
//    {
//        int i = 0;
//        while (i++ < 4)
//            GiveCardToHand(deck, hand);
//    }
//    void GiveCardToHand(List<SCard> deck, Transform hand)
//    {
//        if (deck.Count == 0)
//            return;
//        CreateCardPref(deck[0], hand);
            

//        deck.RemoveAt(0);
//    }

//    void CreateCardPref(SCard card, Transform hand)
//    {
//        GameObject cardGO = Instantiate(CardPref, hand, false);
//        CardController cardC = cardGO.GetComponent<CardController>();

//        cardC.Init(card, hand == PlayerHand);

//        if(cardC.IsPlayerCard)
//            PlayerHandCards.Add(cardC);
//        else
//            EnemyHandCards.Add(cardC);
//    }

//    IEnumerator TurnFunc()
//    {
//        TurnTime = 30;
//        TurnTimeTxt.text = TurnTime.ToString();
//        if (IsPlayerTurn)
//        {
//            foreach (var card in PlayerFieldCards)
//                card.SelfCard.ChangeAttackState(true);
//            while(TurnTime-- > 0)
//            {
//                TurnTimeTxt.text = TurnTime.ToString();
//                yield return new WaitForSeconds(1);
//            }

//        }
//        else
//        {
//            foreach (var card in EnemyFieldCards)
//                card.SelfCard.ChangeAttackState(true);
//            while (TurnTime-- > 25)
//            {
//                TurnTimeTxt.text = TurnTime.ToString();
//                yield return new WaitForSeconds(1);
//            }

//            if (EnemyHandCards.Count > 0)
//                EnemyTurn(EnemyHandCards);
//        }
//        ChangeTurn();
//    }

//    void EnemyTurn(List<CardController> cards)
//    {
//        int count = Random.Range(0, cards.Count + 1);
//        for(int i=0; i < count; i++)
//        {
//            if (EnemyFieldCards.Count > 4)
//                return;
//            cards[0].Info.ShowCardInfo();
//            cards[0].transform.SetParent(EnemyField);
//            EnemyFieldCards.Add(cards[0]);
//            EnemyHandCards.Remove(cards[0]);
//        }
//        foreach(var activeCard in EnemyFieldCards.FindAll(x=> x.Card.CanAttack))
//        {
//            if (PlayerFieldCards.Count == 0)
//                return;
//            var enemy = PlayerFieldCards[Random.Range(0, PlayerFieldCards.Count)];
//            CardsFight(activeCard, enemy);
//            activeCard.Card.ChangeAttackState(false);
            
//        }
//    }

//    public void ChangeTurn()
//    {
//        StopAllCoroutines();
//        Turn++;
//        EndTurnBtn.interactable = IsPlayerTurn;
//        if(IsPlayerTurn)
//            GivenNewCards();
//        StartCoroutine(TurnFunc());
//    }

//    void GivenNewCards()
//    {
//        GiveCardToHand(CurrentGame.EnemyDeck, EnemyHand);
//        GiveCardToHand(CurrentGame.PlayerDeck, PlayerHand);
//    }

//    public void CardsFight(CardController playerCard, CardController enemyCard)
//    {
//        enemyCard.Card.GetDamage(playerCard.Card.atk);

//        playerCard.CheckForAlive();
//        enemyCard.CheckForAlive();
//    }

//    //void DestroyCard(CardInfoScript card)
//    //{
//    //    card.GetComponent<CardMovementScript>().OnEndDrag(null);
//    //    if (EnemyFieldCards.Exists(x => x == card))
//    //        EnemyFieldCards.Remove(card);

//    //    if (PlayerFieldCards.Exists(x => x == card))
//    //        PlayerFieldCards.Remove(card);

//    //    Destroy(card.gameObject);
//    //}
//}
