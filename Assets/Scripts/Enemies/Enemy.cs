using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;

    private Animator animator;

    protected GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        if (health <= 0) Death();
    }

    protected void Death()
    {
        speed = 0;
        gameObject.GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("Death");
        player.GetComponent<PlayerStats>().killes++;
        Destroy(gameObject, 2f);
    }


}
