using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bost : MonoBehaviour
{
    public PlayerController playerController;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController._timeron = true;
            Destroy(gameObject);
        }
    }
}
