using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// SettingsMenu script // Script fore settings which process
/// Quit Button , Volume Slider , Resolution Dropdown,
/// Graphics Dropdown and FullScreen Toggle
/// </summary>
public class SettingsMenu : MenuManager
{
    [SerializeField] Dropdown resolutionDropdown;
    [SerializeField] Dropdown graphicsDropdown;
    [SerializeField] Slider volumeSlider;

    public AudioMixer audioMixer;
    private Resolution[] resolutions;

    /// <summary>
    /// Setting old values
    /// </summary>
    void Awake()
    {
        //Getting Old values and save it
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        graphicsDropdown.value = PlayerPrefs.GetInt("qualityIndex");
    }

    /// <summary>
    /// Adding all variants of resolution to our DropDown
    /// </summary>
    void Start()
    {
        int CurrentResolutionIndex = 0;
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(Option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = CurrentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public override void HandleQuitButtonOnClickEvent()
    {
        MenuManager.SwitchToScene(MenuName.MainMenu);
    }

    /// <summary>
    /// Handles the on click event from the Resolution Dropdown
    /// </summary>
    /// <param name="ResolutionIndex"></param>
    public void HandleResolutionDropdownOnClickEvent(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResoultionIndex", ResolutionIndex);
       
    }
    /// <summary>
    /// Handles the on click event from the Volume Slider
    /// </summary>
    /// <param name="volume"></param>
    public void HandleVolumeSliderOnClickEvent(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Handles the on click event from the Graphics Dropdown
    /// </summary>
    /// <param name="qualityIndex"></param>
    public void HandleQualityDropdownOnClickEvent(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Handles the on click event from the Fullscreen Toggle
    /// </summary>
    /// <param name="fullscreen"></param>
    public void HandleFullscreenToggleOnClickEvent(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
}