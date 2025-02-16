using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// FinishLineTrigger script // Checking Finish Line
/// and change count of laps and Stops game 
/// </summary>
public sealed class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    private TextManager _textManager;

    /// <summary>
    /// Getting textManager from HUD and set text of count of Laps 
    /// </summary>
    private void Start()
    {
        _textManager = HUD.GetComponent<TextManager>();

        _textManager.car1LapsText.text = TextManager.CountOfLapsCar1 + "/" + TextManager.MaxCountOfLaps;
        _textManager.car2LapsText.text = TextManager.CountOfLapsCar2 + "/" + TextManager.MaxCountOfLaps;
    }

    /// <summary>
    /// Checking the collison between car and trigger and adding laps
    /// </summary>
    /// <param name="trigger"></param>
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        //Checking car1 and adding laps for it
        if (trigger.gameObject.tag == "Car1")
        {
           TextManager.CountOfLapsCar1++;
           _textManager.car1LapsText.text = TextManager.CountOfLapsCar1 + "/" + TextManager.MaxCountOfLaps;

           //Cheking count of laps
           if (TextManager.CountOfLapsCar1 == TextManager.MaxCountOfLaps + 1)
           {
                TextManager.CountOfLapsCar1 = TextManager.MaxCountOfLaps;
                _textManager.car1LapsText.text = TextManager.CountOfLapsCar1 + "/" + TextManager.MaxCountOfLaps;
                _textManager.StopGame();
           }
        }

        //Checking car2 and adding laps for it
        if (trigger.gameObject.tag == "Car2")
        { 
           TextManager.CountOfLapsCar2++;
           _textManager.car2LapsText.text = TextManager.CountOfLapsCar2 + "/" + TextManager.MaxCountOfLaps;

           //Cheking count of laps
           if (TextManager.CountOfLapsCar2 == TextManager.MaxCountOfLaps + 1)
           {
                TextManager.CountOfLapsCar2 = TextManager.MaxCountOfLaps;
                _textManager.car2LapsText.text = TextManager.CountOfLapsCar2 + "/" + TextManager.MaxCountOfLaps;
                _textManager.StopGame();
           }
        }


    }
}
