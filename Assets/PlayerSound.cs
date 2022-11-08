using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audioSource;

    [SerializeField]
    AudioClip outOfBounds;
    AudioSource myOutOfBounds;

    [Range(0.1f, 0.5f)]
    public float pitchMulti = 0.2f;

    private void Start(){
        audioSource = GetComponent<AudioSource>();
        myOutOfBounds = GetComponent<AudioSource>();
    }

    public void FallingSound(){
        myOutOfBounds.clip = outOfBounds;
        myOutOfBounds.PlayOneShot(myOutOfBounds.clip);
    }

    public void DamageSound(){
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        //audioSource.pitch = Random.Range(1 - pitchMulti, 1 + pitchMulti);
        audioSource.PlayOneShot(audioSource.clip);
    }
}
