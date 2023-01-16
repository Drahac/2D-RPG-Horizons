using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] playList;
    private AudioSource audioSource;

    private int musicIndex =0;
    [SerializeField] private AudioMixerGroup soundEffectMixer;


    public static AudioManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("Il y a plus d'une Instance d' AudioManager dans la scène");
            return;
        }

        Instance = this;
    }

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


    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject go = new GameObject();
        go.transform.position = pos;

        AudioSource audioSource = go.AddComponent<AudioSource>();

        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(go, clip.length);

        return audioSource;
    }
}
