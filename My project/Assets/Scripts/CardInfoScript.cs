using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScript : MonoBehaviour
{
    public SCard SelfCard;
    public Image Img;

    public void HideCardInfo(SCard card)
    {
        SelfCard = card;
        Img.sprite = null;
    }

    public void ShowCardInfo(SCard card)
    {
        SelfCard = card;
        
        Img.sprite = card.Img;
        Img.preserveAspect = true;
    }

    private void Start()
    {
        ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]);
    }
}
