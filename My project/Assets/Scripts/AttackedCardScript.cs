using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackedCardScript : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardInfoScript card = eventData.pointerDrag.GetComponent<CardInfoScript>();
        if (card && transform.parent == GetComponent<CardMovementScript>().GameManager.EnemyField && card.SelfCard.CanAttack)
        {
            card.SelfCard.ChangeAttackState(false);

            GetComponent<CardMovementScript>().GameManager.CardsFight(card, GetComponent<CardInfoScript>());
        }
    }
}
