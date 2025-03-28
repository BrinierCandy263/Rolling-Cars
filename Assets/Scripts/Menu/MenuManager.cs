﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MenuManager // Additional class which helps
/// other scripts to work with Menus and more
/// </summary>
public class MenuManager : MonoBehaviour
{
    protected static bool _initializedPauseMenu = false;
    protected static bool _initializedWinMessage = false;
    protected static bool _initializedTrafficLightTextMenu = false;

    public static bool InitializedPauseMenu {get => _initializedPauseMenu;}
    public static bool InitializedWinMessage {get => _initializedWinMessage;}
    public static bool InitializedTrafficLightTextMenu {get => _initializedTrafficLightTextMenu;}


    /// <summary>
    /// Handle Quit Button method with Base For PolyMorphism 
    /// </summary>
    public virtual void HandleQuitButtonOnClickEvent()
    {
    }

    /// <summary>
    /// Goes to the menu with the given name
    /// </summary>
    /// <param name="menuName">name of the menu to go to</param>
    public static void SwitchToScene(MenuName menuName)
    {
        switch (menuName)
        {
            case (MenuName.MainMenu):
                {
                    //Go to MainMenu scene
                    SceneManager.LoadScene("MainMenu");
                    Cursor.visible = true;
                    break;
                }
            case (MenuName.MultiPlayerOnlineMenu):
                {
                    //Go to MainMenu scene
                    SceneManager.LoadScene("MultiplayerMainMenu");
                    Cursor.visible = true;
                    break;
                }
            
            case (MenuName.MapSelector):
                {
                    //Go to MainMenu scene
                    SceneManager.LoadScene("Map_Selector");
                    Cursor.visible = true;
                    break;
                }
            case (MenuName.Car1ChooseMenu):
                {
                    //Go to MainMenu scene
                    SceneManager.LoadScene("Car1ChooseMenu");
                    Cursor.visible = true;
                    break;
                }
            case (MenuName.Car2ChooseMenu):
                {
                    //Go to MainMenu scene
                    SceneManager.LoadScene("Car2ChooseMenu");
                    Cursor.visible = true;
                    break;
                }
            case (MenuName.Level1):
                {
                    //Go to Game White Mode Scene
                    SceneManager.LoadScene("Level1");
                    Cursor.visible = false;
                    break;
                }
            case (MenuName.Level2):
                {
                    //Go to Game White Mode Scene
                    SceneManager.LoadScene("Level2");
                    Cursor.visible = false;
                    break;
                }
            case (MenuName.Level3):
                {
                    //Go to Game White Mode Scene
                    SceneManager.LoadScene("Level3");
                    Cursor.visible = false;
                    break;
                }
            case (MenuName.Level4):
                {
                    //Go to Game White Mode Scene
                    SceneManager.LoadScene("Level4");
                    Cursor.visible = false;
                    break;
                }
            case (MenuName.Settings):
                {
                    //Go to Settings Menu
                    SceneManager.LoadScene("Settings");
                    Cursor.visible = true;
                    break;
                }
            case MenuName.Pause:
                {
                    if (!_initializedPauseMenu && !_initializedWinMessage)
                    {
                        //Instantiate prefab of PauseMenu
                        Object.Instantiate(Resources.Load("PauseMenu"));
                        _initializedPauseMenu = true;
                        Cursor.visible = true;
                    }
                    break;
                }
                
            case (MenuName.WinMessage):
                {
                    //Instantiate prefab of WinMessage
                    Object.Instantiate(Resources.Load("WinMessage"));
                    _initializedWinMessage = true;
                    Cursor.visible = true;
                    break;
                }
        }

    }

}
