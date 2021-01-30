using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public SceneClass sceneClass;

    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundSlider;

    public void Start()
    {
        //Sets the slider value to whatever the slider value was last
        masterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        soundSlider.value = PlayerPrefs.GetFloat("SoundVol");
    }

    public void BackBttn()
    {
        SceneManager.UnloadSceneAsync("Options");
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
        PlayerPrefs.SetFloat("MasterVol", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVol", volume);
        PlayerPrefs.SetFloat("MusicVol", volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundVol", volume);
        PlayerPrefs.SetFloat("SoundVol", volume);
    }
}
