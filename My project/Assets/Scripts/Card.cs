using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, /*IPointerDownHandler, IPointerUpHandler,*/ IPointerClickHandler{
    protected int atk;
    protected int dod;
    protected int arm;
    protected bool cheked;
    Card()
    {
        atk = 0;
        dod = 0;
        arm = 0;
        cheked = false;
    }
    void SetInfo()
    {
        string CardName = this.GetComponent<Image>().sprite.name;
        atk = (int)Char.GetNumericValue(CardName[0]);
        dod = (int)Char.GetNumericValue(CardName[1]);
        arm = (int)Char.GetNumericValue(CardName[2]);
        Debug.Log(atk + " " + dod + " " + arm);
    }
    /*public void OnPointerDown(PointerEventData pointerEventData)
    {
        GetComponent<CanvasGroup>().alpha = .6f;
        Debug.Log("clicked");
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        GetComponent<CanvasGroup>().alpha = 1f;
    }*/
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        cheked = !cheked;
    }
    void Awake()
    {
        SpriteRenderer sprite;
        sprite = GetComponent<SpriteRenderer>();
        SetInfo();
    }
    void Update(){
        if (cheked)
            GetComponent<CanvasGroup>().alpha = .6f;
        else
            GetComponent<CanvasGroup>().alpha = 1f;
    }
}
