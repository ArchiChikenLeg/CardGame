using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackedCardScript : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (!GameManagerScript.Instance.IsPlayerTurn)
            return;
        CardController card = eventData.pointerDrag.GetComponent<CardController>();
        if (card && transform.parent == GetComponent<CardMovementScript>().GameManager.EnemyField && card.Card.CanAttack)
        {
            card.Card.ChangeAttackState(false);

            GetComponent<CardMovementScript>().GameManager.CardsFight(card, GetComponent<CardController>());
        }
    }
}
