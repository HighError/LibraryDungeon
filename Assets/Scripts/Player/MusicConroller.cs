using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicConroller : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip[] runMusic;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            ChangeMusic(SceneManager.GetActiveScene().name == "Menu");
        }
    }
    public void ChangeMusic(bool isMenu)
    {
        if (isMenu)
        {
            audioSource.clip = menuMusic;
        }
        else
        {
            int rnd = Random.Range(0, runMusic.Length);
            audioSource.clip = runMusic[rnd];
        }
        audioSource.Play();
    }
}
