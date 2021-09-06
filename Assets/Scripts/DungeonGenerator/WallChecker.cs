using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject door;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            //Debug.LogError($"{gameObject.name}, {gameObject.transform.parent.name}, {gameObject.transform.parent.parent.name} | {other.name}");
            wall.SetActive(true);
            //wall.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            //wall.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(door);
            Destroy(gameObject);
        }
    }
}
