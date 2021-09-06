using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToGame : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SceneMove("Menu");
    }
}
