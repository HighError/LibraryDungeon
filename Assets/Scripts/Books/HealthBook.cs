using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBook : Book
{
    public override void Use()
    {
        PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //player.UseBook(bookName, description);
        player.health += stat;
        if (player.health >= player.maxHealth) player.health = player.maxHealth;
        else if (player.health <= 0.1) player.health = 0.1f;
    }
}
