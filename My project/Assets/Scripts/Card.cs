using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler{
    protected int atk;
    protected int dod;
    protected int arm;
    Card()
    {
        //string CardName = this.GetComponent<Image>().sprite.name;
        atk = 0;
        dod = 0;
        arm = 0;
    }
    void SetInfo()
    {
        string CardName = this.GetComponent<Image>().sprite.name;
        atk = (int)Char.GetNumericValue(CardName[0]);
        dod = (int)Char.GetNumericValue(CardName[1]);
        arm = (int)Char.GetNumericValue(CardName[2]);
        Debug.Log(atk + " " + dod + " " + arm);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().alpha = .6f;
    }
    void Awake()
    {
        SetInfo();
    }
    void Update(){
        
    }
}
