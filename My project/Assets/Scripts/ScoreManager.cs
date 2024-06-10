using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private void Start()
    {
        DataTable card = MyDataBase.GetTable("SELECT * FROM Card ORDER BY card_ID DESC;");
        
        int creature = int.Parse(card.Rows[0][1].ToString());
        
        string nickname = MyDataBase.ExecuteQueryWithAnswer($"SELECT name FROM Card WHERE type_ID = {creature};");
    }
}