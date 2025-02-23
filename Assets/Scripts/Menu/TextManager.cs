using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// TextManager // Additional class which helps
/// other scripts to work with texts and more
/// </summary>
public class TextManager : MonoBehaviour
{
    //declare fields
    private static float _elapsedTime = 0;
    private static int _countOfLapsCar1 = 0;
    private static int _countOfLapsCar2 = 0;
    private static int _maxCountOfLaps = 3;

    public Text elapsedTimeText;
    public Text car1LapsText;
    public Text car2LapsText;

    //declare Properties
    public static float ElapsedTime
    {
        get { return _elapsedTime; }
        set { _elapsedTime = value; }
    }

    public static int MaxCountOfLaps
    {
        get { return _maxCountOfLaps; }
        set { _maxCountOfLaps = value; }
    }

    public static int CountOfLapsCar1
    {
        get { return _countOfLapsCar1; }
        set { _countOfLapsCar1 = value; }
    }

    public static int CountOfLapsCar2
    {
        get { return _countOfLapsCar2; }
        set { _countOfLapsCar2 = value; }
    }

    /// <summary>
    /// Setting elapsedTime, countOfLaps for each car to zero
    /// </summary>
    public static void SetZeroValues()
    {
        //Setting values to zero
        _elapsedTime = 0;
        _countOfLapsCar1 = 0;
        _countOfLapsCar2 = 0;
    }

    /// <summary>
    /// Running Game
    /// </summary>
    public void RunTimer()
    {
        //Running Timer
        _elapsedTime += Time.deltaTime;
        elapsedTimeText.text = _elapsedTime.ToString("0.00");
    }

    /// <summary>
    /// Stopping Game
    /// </summary>
    public void StopGame()
    {
        MenuManager.SwitchToScene(MenuName.WinMessage);
    }
}
