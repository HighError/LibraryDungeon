using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    none = 0,
    bottom = 1,
    left = 2,
    right = 3,
    top = 4,
}
public class RoomSpawner : MonoBehaviour
{
    public Direction openingDirection;

    private RoomTemplates templates;
    private int rnd;
    private bool spawned = false;

    public float timeAfterDestroy = 4f;


    private void Awake()
    {
        Destroy(gameObject, timeAfterDestroy);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (!spawned)
        {
            switch (openingDirection)
            {
                case Direction.bottom:
                    rnd = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rnd], transform.position, templates.bottomRooms[rnd].transform.rotation);
                    break;
                case Direction.left:
                    rnd = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rnd], transform.position, templates.leftRooms[rnd].transform.rotation);
                    break;
                case Direction.right:
                    rnd = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rnd], transform.position, templates.rightRooms[rnd].transform.rotation);
                    break;
                case Direction.top:
                    rnd = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rnd], transform.position, templates.topRooms[rnd].transform.rotation);
                    break;
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (!(other.GetComponent<RoomSpawner>().spawned) && !spawned)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
