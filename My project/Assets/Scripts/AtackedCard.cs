using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AtackedCard : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData)
    {
        GetComponent<Match>().CardsFight(eventData.pointerDrag.GetComponent<Card>(), GetComponent<Card>());
    }
}
