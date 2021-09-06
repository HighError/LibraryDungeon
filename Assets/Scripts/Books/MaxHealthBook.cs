using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthBook : Book
{
    public override void Use()
    {
        PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //player.UseBook(bookName, description);
        player.maxHealth += stat;
        if (player.arrowSpeed <= 0.5) player.arrowSpeed = 0.5f;
    }
}
