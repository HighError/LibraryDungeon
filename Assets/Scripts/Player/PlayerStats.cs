using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health Stats")]
    public float maxHealth;
    public float health;

    [Header("Staff Stats")]
    public float damage;
    public float reloadTime;
    public float arrowSpeed;

    [Header("Other Stats")]
    public float speed;

    [Header("Books")]
    public List<GameObject> books;

    [Header("Run")]
    public int loop;
    public int killes;

    [Header("Records")]
    public int killsRecord = 0;
    public int loopRecord = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Kills")) killsRecord = PlayerPrefs.GetInt("Kills");
        if (PlayerPrefs.HasKey("Loop")) loopRecord = PlayerPrefs.GetInt("Loop");
    }

    public void ResetPlayer()
    {
        CheckRecord(killes, loop);

        maxHealth = 2;
        health = 2;
        damage = 1;
        reloadTime = 2;
        arrowSpeed = 4;

        loop = 0;
        killes = 0;

        books.Clear();
        transform.GetChild(2).GetComponent<UiUpdate>().UpdateUI();
    }

    public void CheckRecord(int _kills, int _loop)
    {
        if (_kills > killsRecord) killsRecord = _kills;
        if (_loop > loopRecord) killsRecord = _loop;
        PlayerPrefs.SetInt("Kills", killsRecord);
        PlayerPrefs.SetInt("Loop", loopRecord);
        transform.GetChild(2).GetComponent<UiUpdate>().UpdateUI();
    }
}
