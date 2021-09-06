using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private bool isComplete = false;
    public List<EnemySpawner> enemySpawner;
    [SerializeField] private GameObject[] doors;

    private List<GameObject> enemy = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isComplete) {
            foreach (var door in doors)
            {
                ChangeDoorStatus(door, false);
            }
            foreach (var spawner in enemySpawner)
            {
                enemy.Add(spawner.Spawn());
            }
            if (enemy.Count == 0)
            {
                isComplete = true;
                foreach (var door in doors)
                {
                    ChangeDoorStatus(door, true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemy.Remove(collision.gameObject);
            if (enemy.Count == 0)
            {
                isComplete = true;
                foreach (var door in doors)
                {
                    ChangeDoorStatus(door, true);
                }
            }
        }
    }

    private void ChangeDoorStatus(GameObject door, bool state)
    {
        if (door != null)
        {
            door.transform.GetChild(0).gameObject.SetActive(!state);
            door.transform.GetChild(1).gameObject.SetActive(state);
        }
    }
}
