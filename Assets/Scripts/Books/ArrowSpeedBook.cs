using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpeedBook : Book
{
    public override void Use()
    {
        PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //player.UseBook(bookName, description);
        player.arrowSpeed += stat;
        if (player.arrowSpeed >= 8) player.arrowSpeed = 8;
        else if (player.arrowSpeed <= 0.5) player.arrowSpeed = 0.5f;
    }
}
