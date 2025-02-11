using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// PauseMenu script // Pauses and unpauses the game, Listens for the OnClick 
/// events for the pause menu buttons
/// </summary>
public sealed class PauseMenu : MenuManager
{
    [SerializeField] private Sprite backGroundDark;
    [SerializeField] private Sprite backGroundLight;
    [SerializeField] private Sprite colorModeBackGroundLight;
    [SerializeField] private Sprite colorModeBackGroundDark;

    [SerializeField] private Text colorModeText;
    [SerializeField] private Text menuText;
    [SerializeField] private Text resumeButtonText;
    [SerializeField] private Text quitButtonText;

    [SerializeField] private Image colorModeBackGroundImage;
    [SerializeField] private Image backGroundImage;

    private GameObject _dividerLine;

    private void Awake()
    {   
        _dividerLine = GameObject.FindGameObjectWithTag("DividerLine");
        if (_dividerLine == null) Debug.LogError("No Divider lIne found with the 'DividerLine' tag.");

        //Pause the game when added to the scene and switch color mode
        Time.timeScale = 0;
        _dividerLine.SetActive(false);
    }



    /// <summary>
    /// Handles the on click event from the Resume button
    /// </summary>
    public void HandleResumeButtonOnClickEvent()
    {
        // unpause game and destroy menu
        Time.timeScale = 1;
        _dividerLine.SetActive(true);

        Destroy(gameObject);
        MenuManager._initializedPauseMenu = false;
    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public override void HandleQuitButtonOnClickEvent()
    {
        //Unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager._initializedPauseMenu = false;
        MenuManager.SwitchToScene(MenuName.MainMenu);
    }
}
