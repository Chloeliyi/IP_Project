/*
 * Author: Pang Le Xin (with reference to KapKoder on YT)
 * Date: 25/06/2023
 * Description: Manages the audio in the game
 */

using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Audio mixer
    /// </summary>
    [SerializeField] AudioMixer mixer;
    /// <summary>
    /// audio manager instance
    /// </summary>
    public static AudioManager instance;
    /// <summary>
    /// constant string for Master Volume Key
    /// </summary>
    public const string MASTER_KEY = "masterVolume";

    /// <summary>
    /// constant string for SFX Volume Key
    /// </summary>
    public const string SFX_KEY = "sfxVolume";

    /// <summary>
    /// constant string for BGM Volume Key
    /// </summary>
    public const string BGM_KEY = "bgmVolume";

    public Sound[] sounds;

    /// <summary>
    /// Awake function
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadVolume();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }
    }

    
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound:" + name + " not found! ");
            return;
        }
        Debug.Log(name + " started playing.");
        s.source.Play();
    }

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        Debug.Log(name + " stoped playing.");
        s.source.Stop();
    }

    /// <summary>
    /// Load the volume 
    /// </summary>
    void LoadVolume()// volume saved in VolumeSettings.cs
    {
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        float bgmVolume = PlayerPrefs.GetFloat(BGM_KEY, 1f);


        mixer.SetFloat(VolumeSettings.MIXER_MASTER, Mathf.Log10(masterVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_BGM, Mathf.Log10(bgmVolume) * 20);
    }
}
