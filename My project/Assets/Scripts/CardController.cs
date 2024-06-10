//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CardController : MonoBehaviour
//{
//    public SCard Card;
//    public bool IsPlayerCard;
//    public CardInfoScript Info;
//    public CardMovementScript Movement;

//    GameManagerScript gameManager;

//    public void Init(SCard card, bool isPlayerCard)
//    {
//        Card = card;
//        gameManager = GameManagerScript.Instance;
//        IsPlayerCard = isPlayerCard;

//        if (IsPlayerCard)
//        {
//            Info.ShowCardInfo();
//            GetComponent<AttackedCardScript>().enabled = false;
//        }
//        else
//        {
//            Info.HideCardInfo();
//        }
//    }

//    public void CheckForAlive()
//    {
//        if (Card.IsAlive)
//            Info.RefreshData();
//        else
//            DestroyCard();
//    }
//    public void DestroyCard()
//    {
//        Movement.OnEndDrag(null);
//        RemoveCardFromList(gameManager.EnemyFieldCards);
//        RemoveCardFromList(gameManager.EnemyHandCards);
//        RemoveCardFromList(gameManager.PlayerFieldCards);
//        RemoveCardFromList(gameManager.PlayerHandCards);
//        Destroy(gameObject);
//    }

//    void RemoveCardFromList(List<CardController> list)
//    {
//        if (list.exist(x => x == this))
//            list.Remove(this);
//    }
//}

