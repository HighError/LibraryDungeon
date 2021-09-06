using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SfxType
{
    Damage,
    Attack
}
public class SfxManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [Space(20)]
    [SerializeField] private AudioClip[] damage;
    [SerializeField] private AudioClip[] attack;

    public void PlaySfx(SfxType type)
    {
        GameObject temp = Instantiate(prefab, transform.position, Quaternion.identity);
        var audioSource = temp.GetComponent<AudioSource>();
        int rnd;
        switch (type)
        {
            case SfxType.Damage:
                rnd = Random.Range(0, damage.Length);
                audioSource.clip = damage[rnd];
                audioSource.Play();
                break;
            case SfxType.Attack:
                rnd = Random.Range(0, attack.Length);
                audioSource.clip = attack[rnd];
                audioSource.Play();
                break;
        }

        if (audioSource.clip == null) Destroy(temp);
        else Destroy(temp, audioSource.clip.length + 1f);
    }
}
