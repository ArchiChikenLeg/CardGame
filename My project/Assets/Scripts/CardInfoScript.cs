using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScript : MonoBehaviour
{
    public CardController CC;
    //public SCard SelfCard;
    public Image Img;
    public TextMeshProUGUI atk, def;
    public GameObject Back;
    //public bool IsPlayer;

    public void HideCardInfo()
    {
       // SelfCard = card;
        Back.SetActive(true);
        //IsPlayer = false;
    }
   
    public void ShowCardInfo()
    {
       // IsPlayer = isPlayer;
       // SelfCard = card;

        Back.SetActive(false); 
        Img.sprite = CC.Card.Img;
        Img.preserveAspect = true;

        atk.text = CC.Card.atk.ToString();
        def.text = CC.Card.def.ToString();
    }

    public void RefreshData()
    {
        atk.text = CC.Card.atk.ToString();
        def.text = CC.Card.def.ToString();
    }



}
