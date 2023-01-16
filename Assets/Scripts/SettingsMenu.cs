using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private Resolution[] resolutions;

    [SerializeField] private Dropdown dropDown;


    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEffectSlider;
    private void Start()
    {
        audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;
        audioMixer.GetFloat("SoundEffect", out float soundValueForSlider);
        soundEffectSlider.value = soundValueForSlider;

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height= resolution.height}).Distinct().ToArray();

        dropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i=0; i < resolutions.Length; i++ )
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;

            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropDown.AddOptions(options);
        dropDown.value = currentResolutionIndex;
        dropDown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Music",volume);
    }

    public void SetSound(float volume)
    {
        audioMixer.SetFloat("SoundEffect", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }


}
