using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private GameObject playerSprite;
    private Animator animator;

    private float cooldownBook;

    public UiUpdate uiUpdate;

    [SerializeField] private MusicConroller musicController;

    [Header("Invisible Stats")]
    [SerializeField] private int invisibleTime;
    private bool invisible;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();

        playerSprite = transform.GetChild(0).gameObject;
        animator = playerSprite.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }
    public void Move(InputAction.CallbackContext input)
    {
        Vector2 inputVec = input.ReadValue<Vector2>();
        bool move = inputVec.x != 0 || inputVec.y != 0;
        bool moveright = inputVec.x > 0;
        moveVelocity = new Vector2(inputVec.x, inputVec.y) * playerStats.speed;
        animator.SetBool("move", move);
        if (move)
            playerSprite.transform.rotation = new Quaternion(0, moveright ? 0 : 180, 0, 0);
    }
    public void TakeDamage(float _damage)
    {
        if (!invisible && playerStats.health > 0)
        {
            transform.GetChild(3).GetComponent<SfxManager>().PlaySfx(SfxType.Damage);
            animator.SetTrigger("Damage");
            playerStats.health -= _damage;
            if (playerStats.health <= 0)
            {
                Death();
                return;
            }
            uiUpdate.UpdateUI();
            StartCoroutine(TakeInvisible());
        }
            
    }
    private IEnumerator TakeInvisible()
    {
        invisible = true;
        float timer = invisibleTime;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        invisible = false;
    }
    public void SceneMove(string _sceneName)
    {
        transform.position = Vector3.zero;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        //musicController.ChangeMusic(_sceneName == "Menu");
        GetComponent<PlayerInput>().enabled = true;
        SceneManager.LoadScene(_sceneName);
    }
    private void Death()
    {
        animator.SetTrigger("Death");
        GetComponent<PlayerInput>().enabled = false;
        playerSprite.SetActive(false);
        playerSprite.SetActive(true);
        uiUpdate.OpenDeathMenu();
        uiUpdate.UpdateUI();
    }
    public void UseBook(InputAction.CallbackContext input)
    {
        if (playerStats.books.Count >= 1 && cooldownBook<= 0)
        {
            var temp = playerStats.books[0].GetComponent<Book>();
            temp.Use();
            uiUpdate.ShowBookInfo(temp.name, temp.description);
            playerStats.books.RemoveAt(0);
            uiUpdate.UpdateUI();
            StartCoroutine(CooldownBookUsing());
        }
    }
    private IEnumerator CooldownBookUsing()
    {
        cooldownBook = 5f;
        while (cooldownBook > 0)
        {
            cooldownBook -= Time.deltaTime;
            uiUpdate.UpdateBookTimer(cooldownBook);
            yield return null;
        }
        cooldownBook = 0;
        uiUpdate.UpdateBookTimer(cooldownBook);
    }
    public void Flaming(float time)
    {
        for (float i = 0; i < time/2; i++)
        {
            TakeDamage(0.25f);
        }
        uiUpdate.UpdateUI();
    }
    public void GoHome()
    {
        uiUpdate.CloseDeathMenu();
        SceneMove("Menu");
        playerStats.ResetPlayer();
        uiUpdate.UpdateUI();
    }
    public void DropAllBook(InputAction.CallbackContext input)
    {
        playerStats.books.Clear();
        uiUpdate.UpdateUI();
    }
}
