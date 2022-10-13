using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CradSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private void Awake(){
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnPointerEnter(PointerEventData eventData){
        canvasGroup.alpha = .6f;
    }
    public void OnPointerExit(PointerEventData eventData){
        canvasGroup.alpha = 0f;
    }
    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

}
