using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager Instance { get; private set; }
    public AudioSource musicPlayer, soundPlayer;
    public AudioClip[] availableSoundClips;
    private Dictionary<string, AudioClip> loadedAudioClips;
    void start()
    {
        loadedAudioClips = new Dictionary<string, AudioClip>();

        foreach (AudioClip audio in availableSoundClips)
        {
            loadedAudioClips.Add(audio.name,audio);
        }
        musicPlayer.Play(); 
    }

    public void PlaySound(string name)
    {
        soundPlayer.clip = loadedAudioClips[name];
        soundPlayer.Play();
    }

    public void StopMusic()
    {
        musicPlayer.Stop();
    }

    void awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
