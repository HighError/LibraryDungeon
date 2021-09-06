using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBook : Book
{
    public override void Use()
    {
        PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //player.UseBook(bookName, description);
        player.speed += stat;
        if (player.speed >= 8) player.speed = 8;
        else if (player.speed <= 0.5) player.speed = 0.5f;
    }
}
