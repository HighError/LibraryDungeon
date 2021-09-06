using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] Vector3 cameraChangePos;
    [SerializeField] Vector3 playerChangePos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position += playerChangePos;
            Camera.main.transform.position += cameraChangePos;
        }

    }
}
