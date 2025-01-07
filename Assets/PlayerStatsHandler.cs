using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsHandler : MonoBehaviour
{
    public static int Money;
    public int startMoney = 4;
    public TMP_Text moneyText;


    private void Start()
    {
        Money = startMoney;
    }

    private void Update()
    {
        moneyText.text = ("Currency: " + Money.ToString());
    }

    public void ChangeMoney(int amount)
    {
        Money += amount;
    }
}
