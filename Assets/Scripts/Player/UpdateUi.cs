using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUi : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetComponent<UiUpdate>().UpdateUI();
        }
    }
}
