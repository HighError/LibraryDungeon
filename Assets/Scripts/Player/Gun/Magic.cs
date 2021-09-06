using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magic : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private float reloadingTimer;
    private PlayerStats player;

    private void Start()
    {
        player = transform.parent.GetComponent<PlayerStats>();
    }

    public void Shoot(InputAction.CallbackContext input)
    {
        if (reloadingTimer <= 0)
        {
            player.transform.GetChild(3).GetComponent<SfxManager>().PlaySfx(SfxType.Attack);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - transform.position;
            lookDir.Normalize();

            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, angle));

            reloadingTimer = player.reloadTime;
        }
    }

    private void FixedUpdate()
    {
        if (reloadingTimer > 0) reloadingTimer -= Time.deltaTime;
        if (reloadingTimer < 0) reloadingTimer = 0;
    }

}
