using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public string bookName;
    public string description;

    [SerializeField] private string statName;
    [SerializeField] protected float stat;

    private void Start()
    {
        stat = (float)Math.Round(UnityEngine.Random.Range(-1.5f, 1.5f), 2);
        description = stat > 0 ? $"{statName} +{stat}" : $"{statName} {stat}";
    }

    public virtual void Use(){}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            RoomTemplates roomTemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            GameObject temp = roomTemplate.books.Find(r => r.GetComponent<Book>().bookName == bookName);
            temp.GetComponent<Book>().stat = gameObject.GetComponent<Book>().stat;
            temp.GetComponent<Book>().description = gameObject.GetComponent<Book>().description;

            player.books.Add(temp);
            //player.bookPickuped++;
            player.GetComponent<PlayerController>().uiUpdate.UpdateUI();
            Destroy(gameObject);
        }
    }
}
