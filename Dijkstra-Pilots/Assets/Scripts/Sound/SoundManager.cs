using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip shootSound;

    [Range(0f,1f)] public float volume = 0.7f;
    [Range(0f,1f)] public float pitch = 1f;

    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = shootSound;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}



public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    [SerializeField]
    Sounds[] sounds;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 sound manager in scene.");
        }
        else
        {
            instance = this;
        }

    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }

      //  PlaySound("Shoot");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("Sound Manager: did not find sound!");
    }
}