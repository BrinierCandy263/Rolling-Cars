using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WinMenu script // pause game the game, Shows elapsed time
/// and which player wins , and can restart game
/// </summary>
public class WinMenu : MenuManager
{
    [SerializeField] Text winPlayerText;
    [SerializeField] Text elapsedTimeText;
    [SerializeField] Text restartButtonText;
    [SerializeField] Text quitButtonText;

    [SerializeField] Image backGroundImage;
    [SerializeField] Sprite backGroundLightMode;
    [SerializeField] Sprite backGroundDarkMode;

    void Awake()
    {
        //Pause the game when added to the scene
        Time.timeScale = 0;

        //Switch Color Mode and Win Text on Awake
        SwitchColorMode();
        SwitchWonText();

        elapsedTimeText.text = "Your elapsed time is: " + TextManager.ElapsedTime.ToString("0.00") + " seconds";
    }

    /// <summary>
    /// Switch Color Mode Method
    /// </summary>
    protected override void SwitchColorMode()
    {
        //Checking color mode and changing Win Menu
        if (MenuManager.colorMode == ColorMode.Light)
        {
            backGroundImage.sprite = backGroundLightMode;
            elapsedTimeText.color = Color.black;
            winPlayerText.color = Color.black;
            restartButtonText.color = Color.black;
            quitButtonText.color = Color.black;
        }

        else if (MenuManager.colorMode == ColorMode.Dark)
        {
            backGroundImage.sprite = backGroundDarkMode;
            elapsedTimeText.color = Color.white;
            winPlayerText.color = Color.white;
            restartButtonText.color = Color.white;
            quitButtonText.color = Color.white;
        }
    }

    /// <summary>
    /// Switch Won Text Method
    /// </summary>
    void SwitchWonText()
    {
        if(TextManager.CountOfLapsCar1 == TextManager.MaxCountOfLaps + 1)
        {
            winPlayerText.text = "Player1 won!";
        }

        if(TextManager.CountOfLapsCar2 == TextManager.MaxCountOfLaps + 1)
        {
            winPlayerText.text = "Player2 won!"; ;
        }
    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public override void HandleQuitButtonOnClickEvent()
    {
        //Unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.initializedWinMessage = false;
        MenuManager.SwitchToScene(MenuName.MainMenu);
    }

    /// <summary>
    /// Handles the on click event from the Restart Button
    /// </summary>
    public void HandleRestartButtonOnClickEvent()
    {
       //Checking colormode and restarting game
       if(MenuManager.colorMode == ColorMode.Light)
       {
            //Setting to zero game values
            TextManager.SetZeroValues();

            //Restarting Game
            MenuManager.initializedWinMessage = false;
            MenuManager.SwitchToScene(MenuName.GameLightMode);
            Time.timeScale = 1;
       }

       else if(MenuManager.colorMode == ColorMode.Dark)
       {
            //Setting to zero game values
            TextManager.SetZeroValues();

            //Restarting Game
            MenuManager.initializedWinMessage = false;
            MenuManager.SwitchToScene(MenuName.GameDarkMode);
            Time.timeScale = 1;
       }
    }
}