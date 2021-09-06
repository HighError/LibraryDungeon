using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifeTime;
    private PlayerStats player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        Invoke("DeleteArrow", lifeTime);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * player.arrowSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(player.damage);
            DeleteArrow();
        }
    }

    private void DeleteArrow()
    {
        Destroy(gameObject);
    }
}
