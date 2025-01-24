using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// PauseMenu script // Pauses and unpauses the game, Listens for the OnClick 
/// events for the pause menu buttons
/// </summary>
public class PauseMenu : MenuManager
{
    [SerializeField] Sprite backGroundDark;
    [SerializeField] Sprite backGroundLight;
    [SerializeField] Sprite colorModeBackGroundLight;
    [SerializeField] Sprite colorModeBackGroundDark;

    [SerializeField] Text colorModeText;
    [SerializeField] Text menuText;
    [SerializeField] Text resumeButtonText;
    [SerializeField] Text quitButtonText;

    [SerializeField] Image colorModeBackGroundImage;
    [SerializeField] Image backGroundImage;

    void Awake()
    {   
        //Pause the game when added to the scene and switch color mode
        Time.timeScale = 0;
        SwitchColorMode();
    }

    /// <summary>
    /// Switch Color Mode Method
    /// </summary>
    protected override void SwitchColorMode()
    {
        //Checking and changing ColorMode
        if (MenuManager.colorMode == ColorMode.Light)
        {
            colorModeBackGroundImage.sprite = colorModeBackGroundDark;
            backGroundImage.sprite = colorModeBackGroundLight;
            colorModeText.text = "Light Mode";

            colorModeText.color = Color.white;
            menuText.color = Color.black;
            resumeButtonText.color = Color.black;
            quitButtonText.color = Color.black;
        }
        else if (MenuManager.colorMode == ColorMode.Dark)
        {
            colorModeBackGroundImage.sprite = colorModeBackGroundLight;
            backGroundImage.sprite = colorModeBackGroundDark;
            colorModeText.text = "Dark Mode";

            colorModeText.color = Color.black;
            menuText.color = Color.white;
            resumeButtonText.color = Color.white;
            quitButtonText.color = Color.white;
        }
    }

    /// <summary>
    /// Handles the on click event from the Resume button
    /// </summary>
    public void HandleResumeButtonOnClickEvent()
    {
        // unpause game and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.initializedPauseMenu = false;
    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public override void HandleQuitButtonOnClickEvent()
    {
        //Unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.initializedPauseMenu = false;
        MenuManager.colorMode = ColorMode.Light;
        MenuManager.SwitchToScene(MenuName.MainMenu);
    }

    /// <summary>
    /// Handles the on click event from the ColorMode Toggle
    /// </summary>
    /// <param name="colorMode"></param>
    public void HandleColorModeToggleOnClickEvent(bool colorMode)
    {
        //Checking and changing ColorMode
        if (colorMode)
        {
            DontDestroyOnLoad(gameObject);
            MenuManager.SwitchToScene(MenuName.GameLightMode);
            TextManager.SetZeroValues();
            MenuManager.colorMode = ColorMode.Light;
            SwitchColorMode();
        }
       
        else if (!colorMode)
        {
            DontDestroyOnLoad(gameObject);
            MenuManager.SwitchToScene(MenuName.GameDarkMode);
            TextManager.SetZeroValues();
            MenuManager.colorMode = ColorMode.Dark;
            SwitchColorMode();
        }
    }
}
