using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class OptionsMenu : MonoBehaviour
{

    public Toggle inverted;

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string bgmPref = "bgmPref";
    private static readonly string sfxPref = "sfxPref";
    private int firstPlayInt;
    public Slider sfxSlider, bgmSlider;
    private float sfxFloat, bgmFloat;
    public AudioSource bgmAudio;
    public AudioSource[] sfxAudio;

    private void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            bgmFloat = .25f;
            sfxFloat = .75f;
            bgmSlider.value = bgmFloat;
            sfxSlider.value = sfxFloat;
            PlayerPrefs.SetFloat(bgmPref, bgmFloat);
            PlayerPrefs.SetFloat(sfxPref, sfxFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {

            bgmFloat = PlayerPrefs.GetFloat(bgmPref);
            bgmSlider.value = bgmFloat;
           
            sfxFloat = PlayerPrefs.GetFloat(sfxPref);
            sfxSlider.value = sfxFloat;
        }


        if (PlayerPrefs.GetString("Inverted") != "")
        {
            inverted.isOn = bool.Parse(PlayerPrefs.GetString("Inverted"));
        }
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(bgmPref, bgmSlider.value);
        PlayerPrefs.SetFloat(sfxPref, sfxSlider.value);
    }


    public void OnApplicationFocus(bool infocus)
    {
        if(!infocus)
        {
            SaveSoundSetting();
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Apply()
    {
        Debug.Log("ApplySettings");
        PlayerPrefs.SetString("Inverted", inverted.isOn.ToString());
        SaveSoundSetting();

    }


    public void UpdateSound()
    {
        Debug.Log("UpdateSoundSettings");
        bgmAudio.volume = bgmSlider.value;
        for (int i = 0; i < sfxAudio.Length; i++)
        {
            sfxAudio[i].volume = sfxSlider.value;
        }
    }
}