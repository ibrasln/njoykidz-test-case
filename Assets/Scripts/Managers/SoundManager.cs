using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public List<AudioClip> audioClips = new();

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(int index)
    {
        audioSource.pitch = Random.Range(.85f, 1.15f);
        audioSource.PlayOneShot(audioClips[index]);
    }
}
