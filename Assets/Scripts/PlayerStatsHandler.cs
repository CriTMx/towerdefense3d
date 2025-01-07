using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsHandler : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    public int startMoney = 4;
    public int startLives = 5;
    public static int maxLives = 10;


    public TMP_Text moneyText;
    public TMP_Text livesText;


    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    private void Update()
    {
        moneyText.text = ("Currency: " + Money.ToString());
        livesText.text = ("Lives: " + Lives.ToString());
    }

    public static void ChangeMoney(int amount)
    {
        Money += amount;
    }

    public static void ChangeLives(int amount)
    {
        Lives = Mathf.Clamp(Lives+amount, 0, maxLives);
        if (Lives == 0)
        {
            GameStateHandler.instance.EndGame();
        }
    }

}
