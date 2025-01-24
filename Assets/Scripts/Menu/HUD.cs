using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// HUD script // The HUD of game which
/// run game, call pause menu
/// </summary>
public class HUD : MenuManager
{
    TextManager textManager;

    /// <summary>
    /// Getting textManager
    /// </summary>
    void Awake()
    {
        textManager = gameObject.GetComponent<TextManager>();
    }

    /// <summary>
    /// Checking in Update
    /// </summary>
    void Update()
    {
        //Running Game
        textManager.RunTimer();

        //Listening for Escape Button and Switching to Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Joystick2Button9)) MenuManager.SwitchToScene(MenuName.Pause);

        //Switching cursor with checking
        if (MenuManager.InitializedPauseMenu || MenuManager.InitializedWinMessage || MenuManager.InitializedTrafficLightTextMenu)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        
    }
}
