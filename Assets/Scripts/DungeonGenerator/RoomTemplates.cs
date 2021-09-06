using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedSpecialRoom;

    [Header("SpecialRoom")]
    public GameObject boss;
    public GameObject treasure;

    [Header("Books")]
    public List<GameObject> books;


    private void Update()
    {
        if (waitTime <= 0 && !spawnedSpecialRoom)
        {
            for (int i = rooms.Count - 1; i > 0; i--)
            {
                try
                {
                    Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
                    rooms[rooms.Count - 1].GetComponent<Room>().enemySpawner.Clear();
                    break;
                }
                catch
                {
                    continue;
                }
            }

            for (int i = 1; i < rooms.Count - 1; i++)
            {
                if (rooms[i])
                {
                    int rnd = Random.Range(0, 10);
                    if (rnd <= 6)
                    {
                        rnd = Random.Range(0, books.Count);
                        Instantiate(books[rnd], rooms[i].transform.position, Quaternion.identity);
                    }
                }
            }
            spawnedSpecialRoom = true;
        }
        else if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
    }
}
