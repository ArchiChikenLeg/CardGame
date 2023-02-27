using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SCard
{
    public Sprite Img;
    public int atk, def;
    public bool IsAlive
    {
        get
        {
            return def > 0;
        }
    }
    public bool CanAttack;
    public SCard(string ImgPath)
    {
        Img = Resources.Load<Sprite>(ImgPath);
        atk = ImgPath[8] - '0';
        def = ImgPath[10] - '0';
        CanAttack = false;
    }
    public void ChangeAttackState(bool can)
    {
        CanAttack = can;
    }
    public void GetDamage(int dmg)
    {
        def -= dmg;
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
