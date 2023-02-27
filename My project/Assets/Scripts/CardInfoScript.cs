using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScript : MonoBehaviour
{
    public SCard SelfCard;
    public Image Img;
    public TextMeshProUGUI atk, def;
    public GameObject Back;
    public bool IsPlayer;

    public void HideCardInfo(SCard card)
    {
        SelfCard = card;
        Back.SetActive(true);
        IsPlayer = false;
    }
   
    public void ShowCardInfo(SCard card, bool isPlayer)
    {
        IsPlayer = isPlayer;
        SelfCard = card;

        Back.SetActive(false); 
        Img.sprite = card.Img;
        Img.preserveAspect = true;

        atk.text = SelfCard.atk.ToString();
        def.text = SelfCard.def.ToString();
    }

    public void RefreshData()
    {
        atk.text = SelfCard.atk.ToString();
        def.text = SelfCard.def.ToString();
    }



}
