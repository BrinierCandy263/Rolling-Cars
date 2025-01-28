using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MainMenu script // The Main Menu which process
/// Quit Button, Play Button and Settings Button
/// </summary>
public sealed class MainMenu : MenuManager
{
    private TextManager _textManager;

    private void Awake()
    {
        Cursor.visible = true;
        _textManager = new TextManager();
    }

    /// <summary>
    /// Handles the on click event from the play button
    /// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        TextManager.SetZeroValues();
        MenuManager.SwitchToScene(MenuName.GameLightMode);
    }

    /// <summary>
    /// Handles the on click event from the settings button
    /// </summary>
    public void HandleSettingsButtonOnClickEvent()
    {
        MenuManager.SwitchToScene(MenuName.Settings);
    }

    /// <summary>
    /// Handles the on click event from the quit button
    /// </summary>
    public override void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
