using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    private void Update()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume;
            s.source.mute = s.mute;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not Found!");
            return;
        }
        s.source.Play();
    }
}
