using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WinMenu script // pause game the game, Shows elapsed time
/// and which player wins , and can restart game
/// </summary>
public sealed class WinMenu : MenuManager
{
    [SerializeField] private Text winPlayerText;
    [SerializeField] private Text elapsedTimeText;
    [SerializeField] private Text restartButtonText;
    [SerializeField] private Text quitButtonText;

    [SerializeField] private Image backGroundImage;
    [SerializeField] private Sprite backGroundLightMode;
    [SerializeField] private Sprite backGroundDarkMode;

    private GameObject _dividerLine;

    private void Awake()
    {
        _dividerLine = GameObject.FindGameObjectWithTag("DividerLine");
        if (_dividerLine == null) Debug.LogError("No Divider lIne found with the 'DividerLine' tag.");

        //Pause the game when added to the scene
        Time.timeScale = 0;

        _dividerLine.SetActive(false);
        SwitchWonText();

        elapsedTimeText.text = "Your elapsed time is: " + TextManager.ElapsedTime.ToString("0.00") + " seconds";
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
        MenuManager._initializedWinMessage = false;
        MenuManager.SwitchToScene(MenuName.MainMenu);
    }

   
}