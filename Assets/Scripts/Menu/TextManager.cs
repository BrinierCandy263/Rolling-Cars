using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// TextManager // Additional class which helps
/// other scripts to work with texts and more
/// </summary>
public class TextManager : MonoBehaviour
{
    //declare fields
    private static float elapsedTime = 0;
    private static int countOfLapsCar1 = 0;
    private static int countOfLapsCar2 = 0;
    private static int maxCountOfLaps = 3;

    public Text elapsedTimeText;
    public Text car1LapsText;
    public Text car2LapsText;

    //declare Properties
    public static float ElapsedTime
    {
        get { return elapsedTime; }
        set { elapsedTime = value; }
    }

    public static int MaxCountOfLaps
    {
        get { return maxCountOfLaps; }
        set { maxCountOfLaps = value; }
    }

    public static int CountOfLapsCar1
    {
        get { return countOfLapsCar1; }
        set { countOfLapsCar1 = value; }
    }

    public static int CountOfLapsCar2
    {
        get { return countOfLapsCar2; }
        set { countOfLapsCar2 = value; }
    }

    /// <summary>
    /// Setting elapsedTime, countOfLaps for each car to zero
    /// </summary>
    public static void SetZeroValues()
    {
        //Setting values to zero
        elapsedTime = 0;
        countOfLapsCar1 = 0;
        countOfLapsCar2 = 0;
    }

    /// <summary>
    /// Running Game
    /// </summary>
    public void RunTimer()
    {
        //Running Timer
        elapsedTime += Time.deltaTime;
        elapsedTimeText.text = elapsedTime.ToString("0.00");
    }

    /// <summary>
    /// Stopping Game
    /// </summary>
    public void StopGame()
    {
        MenuManager.SwitchToScene(MenuName.WinMessage);
    }
}
