using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] playList;
    private AudioSource audioSource;

    private int musicIndex =0;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = playList[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    private void PlayNextSong()
    {
        musicIndex = (musicIndex+1)%playList.Length;
        audioSource.clip=playList[musicIndex];
        audioSource.Play();
    }
}
