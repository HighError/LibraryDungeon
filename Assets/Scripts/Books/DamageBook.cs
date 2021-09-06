using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBook : Book
{
    public override void Use()
    {
        PlayerStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //player.UseBook(bookName, description);
        player.damage += stat;
        if (player.damage >= 5) player.damage = 5;
        else if (player.damage <= 0.1) player.damage = 0.1f;
    }
}
