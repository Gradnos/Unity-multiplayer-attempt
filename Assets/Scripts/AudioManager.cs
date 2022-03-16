using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<AudioManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null) Destroy(obj:this);
        DontDestroyOnLoad(this);
    }

    [Range(0f,1f)]
    public float gameVolume;

    public Sound[] sounds;
    



    // Start is called before the first frame update

    public void PlayAtPoint(string name, Vector3 location)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        AudioSource.PlayClipAtPoint(s.clip, location, s.volume * gameVolume);
    }

    public void playAtAudioSource(string name, AudioSource source)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        source.PlayOneShot(s.clip, s.volume * gameVolume);
    }



}
