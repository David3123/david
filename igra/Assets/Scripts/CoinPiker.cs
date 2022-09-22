using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPiker : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoneyText.Coin += 1;
            Destroy(gameObject);
        }
    }
}
