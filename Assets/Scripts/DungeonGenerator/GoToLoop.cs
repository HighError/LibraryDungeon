using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLoop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().SceneMove("Game");
            collision.gameObject.GetComponent<PlayerStats>().loop++;
        }
    }
}
