using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Enemy") 
            && !other.CompareTag("Arrow") && !other.CompareTag("Room") 
            && !other.CompareTag("Loop") && !other.CompareTag("SpawnPoint")
            && !other.CompareTag("Book"))
            Destroy(other.gameObject);
    }
}
