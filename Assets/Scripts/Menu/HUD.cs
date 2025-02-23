using UnityEngine;

/// <summary>
/// HUD script // The HUD of game which
/// run game, call pause menu
/// </summary>
public sealed class HUD : MenuManager
{
    private TextManager _textManager;

    /// <summary>
    /// Getting textManager
    /// </summary>
    private void Awake()
    {
        _textManager = gameObject.GetComponent<TextManager>();
    }

    /// <summary>
    /// Checking in Update
    /// </summary>
    private void Update()
    {
        //Running Game
        _textManager.RunTimer();

        //Listening for Escape Button and Switching to Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Joystick2Button9)) MenuManager.SwitchToScene(MenuName.Pause);
    }
}
