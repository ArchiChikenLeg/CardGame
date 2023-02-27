using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SCard
{
    public Sprite Img;
    public int atk, def;
    public SCard(string ImgPath)
    {
        Img = Resources.Load<Sprite>(ImgPath);
        atk = (int)ImgPath[8];
        def = (int)ImgPath[10];
    }
}

public static class CardManager
{
    public static List<SCard> AllCards = new List<SCard>();
}

public class CardManagerScript : MonoBehaviour
{
    public void Awake()
    {
        CardManager.AllCards.Add(new SCard("Sprites/221Perevertsh"));
        CardManager.AllCards.Add(new SCard("Sprites/224BabaYaga"));
        CardManager.AllCards.Add(new SCard("Sprites/224ChertovaDama"));
        CardManager.AllCards.Add(new SCard("Sprites/224ChertovaDama"));
        CardManager.AllCards.Add(new SCard("Sprites/224ChertovaDama"));
        CardManager.AllCards.Add(new SCard("Sprites/224ChertovaDama"));
        CardManager.AllCards.Add(new SCard("Sprites/224ChertovaDama"));
    }
}
