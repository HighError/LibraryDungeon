using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UiUpdate : MonoBehaviour
{
    private PlayerStats player;

    [Header("HP")]
    [SerializeField] private Image hpBar;
    [SerializeField] private Text hpText;

    [Header("Book Info")]
    [SerializeField] private GameObject bookInfo;
    [SerializeField] private Text bookInfoTitle;
    [SerializeField] private Text bookInfoDescription;
    [SerializeField] private Image activeBook;
    [SerializeField] private Text bookCount;
    [SerializeField] private GameObject bookTimerObject;
    [SerializeField] private Text bookTimer;

    [Header("Stats")]
    [SerializeField] private GameObject statsObject;
    [SerializeField] private Text speedText;
    [SerializeField] private Text damageText;
    [SerializeField] private Text arrowSpeedText;

    [Header("Stats2")]
    [SerializeField] private Text killsText;
    [SerializeField] private Text loopText;

    [Header("Record")]
    [SerializeField] private Text killsRecordText;
    [SerializeField] private Text loopRecordText;

    [Header("Death")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Text deathKills;
    [SerializeField] private Text deathLoop;

    private void Start()
    {
        player = transform.parent.GetComponent<PlayerStats>();
    }
    public void UpdateUI()
    {
        hpBar.fillAmount = player.health / player.maxHealth;
        hpText.text = $"HP: {player.health}/{player.maxHealth}";

        if (player.books.Count == 0)
        {
            bookCount.text = "0";
            activeBook.gameObject.SetActive(false);
        }
        else
        {
            activeBook.gameObject.SetActive(true);
            activeBook.sprite = player.books[0].GetComponent<SpriteRenderer>().sprite;
            if (player.books.Count <= 9) bookCount.text = player.books.Count.ToString();
            else bookCount.text = "9+";
        }

        if (statsObject.activeSelf)
        {
            speedText.text = $"Speed: {player.speed}";
            damageText.text = $"Damage: {player.damage}";
            arrowSpeedText.text = $"Arrow Speed: {player.arrowSpeed}";
            killsText.text = $"Kills: {player.killes}";
            loopText.text = $"Loop: {player.loop}";
            killsRecordText.text = $"Kills\n{player.killsRecord}";
            loopRecordText.text = $"Loop\n{player.loopRecord}";
        }
    }
    public void ShowBookInfo(string _title, string _description)
    {
        bookInfo.SetActive(false);
        bookInfo.SetActive(true);
        bookInfoTitle.text = _title;
        bookInfoDescription.text = _description;
        UpdateUI();
    }
    public void ChangeViewStats(InputAction.CallbackContext input)
    {
        statsObject.SetActive(!statsObject.activeSelf);
        UpdateUI();
    }
    public void UpdateBookTimer(float time)
    {
        if (!bookTimerObject.activeSelf) bookTimerObject.SetActive(true);

        time = (float)System.Math.Round(time, 2);
        bookTimer.text = time.ToString();

        if (time <= 0) bookTimerObject.SetActive(false);
        UpdateUI();
    }

    public void OpenDeathMenu()
    {
        deathPanel.SetActive(true);
        deathKills.text = $"Kills: {player.killes}";
        deathLoop.text = $"Loop: {player.loop}";
    }

    public void CloseDeathMenu()
    {
        deathPanel.SetActive(false);
    }
}
