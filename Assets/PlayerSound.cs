using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;

    AudioSource audioSource;

    private void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    public void DamageSound(){
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }
}
