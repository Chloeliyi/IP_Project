/*
 * Author: Pang Le Xin (with reference KapKoder on YT)
 * Date: 25/06/2023
 * Description: manges the UI volume of the game
 */

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    /// <summary>
    /// Audio mixer
    /// </summary>
    [SerializeField] AudioMixer mixer;
    /// <summary>
    /// slider for master volume
    /// </summary>
    [SerializeField] Slider MasterSlider;
    /// <summary>
    /// slider of sfx volume
    /// </summary>
    [SerializeField] Slider SFXSlider;
    /// <summary>
    /// slider for bgm volume
    /// </summary>
    [SerializeField] Slider BGMSlider;


    /// <summary>
    /// constant string for mixer master vol
    /// </summary>
    public const string MIXER_MASTER = "MasterVolume";
    /// <summary>
    /// constant string for mixer sfx vol
    /// </summary>
    public const string MIXER_SFX = "SFXVolume";
    /// <summary>
    /// constant string for mixer bgm vol
    /// </summary>
    public const string MIXER_BGM = "BGMVolume";

    /// <summary>
    /// awake function
    /// </summary>
    private void Awake()
    {
        MasterSlider.onValueChanged.AddListener(SetMasterVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
        BGMSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    /// <summary>
    /// start function
    /// </summary>
    private void Start()
    {
        MasterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, 1f);
        SFXSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
        BGMSlider.value = PlayerPrefs.GetFloat(AudioManager.BGM_KEY, 1f);
    }

    /// <summary>
    /// disable volume 
    /// </summary>
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MASTER_KEY, MasterSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, SFXSlider.value);
        PlayerPrefs.SetFloat(AudioManager.BGM_KEY, BGMSlider.value);
    }

    /// <summary>
    /// Sets the master volume 
    /// </summary>
    /// <param name="value"></param>
    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }
    /// <summary>
    /// Sets the sfxvolume 
    /// </summary>
    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    /// <summary>
    /// Sets the bgm volume 
    /// </summary>
    void SetBGMVolume(float value)
    {
        mixer.SetFloat(MIXER_BGM, Mathf.Log10(value) * 20);
    }
}
