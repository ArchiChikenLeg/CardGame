//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public enum FieldType { 
//    SELF_HAND,
//    SELF_FIELD,
//    ENEMY_HAND,
//    ENEMY_FIELD
//}


//public class DropPlaceScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
//{
//    public FieldType Type;
    
//    public void OnDrop(PointerEventData eventData) {
//        if (Type != FieldType.SELF_FIELD)
//            return;
//        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();
//        if (card && card.GameManager.PlayerFieldCards.Count<5)
//        {
//            card.GameManager.PlayerHandCards.Remove(card.GetComponent<CardInfoScript>());
//            card.GameManager.PlayerFieldCards.Add(card.GetComponent<CardInfoScript>());
//            card.DefaultParent = transform;
//        }
            
//    }

//    public void OnPointerEnter(PointerEventData eventData) {
//        if (eventData.pointerDrag == null || Type == FieldType.ENEMY_FIELD || Type == FieldType.ENEMY_HAND || Type == FieldType.SELF_HAND)
//            return;
//        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();
//        if (card)
//            card.DefaultTempCardParent = transform;
//    }

//    public void OnPointerExit(PointerEventData eventData){
//        if (eventData.pointerDrag == null)
//            return;
//        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();
//        if (card && card.DefaultTempCardParent == transform)
//            card.DefaultTempCardParent = card.DefaultParent;
//    }
//}
