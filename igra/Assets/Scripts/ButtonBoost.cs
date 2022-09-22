using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBoost : MonoBehaviour
{
    public PlayerController playerController;

    public void BuyBoostClick()
    {
        if (MoneyText.Coin >= 10)
        {
            playerController._timeron = true;
            MoneyText.Coin -= 10;
        }
            
    }
}
