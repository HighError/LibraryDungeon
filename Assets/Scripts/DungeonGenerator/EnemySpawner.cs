using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monstersList;
    public GameObject Spawn()
    {
        int rnd = Random.Range(0, monstersList.Length);
        return Instantiate(monstersList[rnd], transform.position, Quaternion.identity);
    }
}
