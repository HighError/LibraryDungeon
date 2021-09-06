using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElemental : Enemy
{
    private void FixedUpdate()
    {
        float temp = (transform.position - player.transform.position).x;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (temp > 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            other.gameObject.GetComponent<PlayerController>().Flaming(Random.Range(2,6));
            Death();
        }
    }
}
