using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// FinishLineTrigger script // Checking Finish Line
/// and change count of laps and Stops game 
/// </summary>
public class FinishLineTrigger : MonoBehaviour
{
    [SerializeField] GameObject HUD;
    TextManager textManager;

    /// <summary>
    /// Getting textManager from HUD and set text of count of Laps 
    /// </summary>
    void Awake()
    {
        textManager = HUD.GetComponent<TextManager>();

        textManager.car1LapsText.text = TextManager.CountOfLapsCar1 + "/" + TextManager.MaxCountOfLaps;
        textManager.car2LapsText.text = TextManager.CountOfLapsCar2 + "/" + TextManager.MaxCountOfLaps;
    }

    /// <summary>
    /// Checking the collison between car and trigger and adding laps
    /// </summary>
    /// <param name="trigger"></param>
    void OnTriggerEnter2D(Collider2D trigger)
    {
        //Checking car1 and adding laps for it
        if (trigger.gameObject.tag == "Car1")
        {
           TextManager.CountOfLapsCar1++;
           textManager.car1LapsText.text = TextManager.CountOfLapsCar1 + "/" + TextManager.MaxCountOfLaps;

           //Cheking count of laps
           if (TextManager.CountOfLapsCar1 == TextManager.MaxCountOfLaps + 1)
           {
                TextManager.CountOfLapsCar1 = TextManager.MaxCountOfLaps;
                textManager.car1LapsText.text = TextManager.CountOfLapsCar1 + "/" + TextManager.MaxCountOfLaps;
                textManager.StopGame();
           }
        }

        //Checking car2 and adding laps for it
        if (trigger.gameObject.tag == "Car2")
        { 
           TextManager.CountOfLapsCar2++;
           textManager.car2LapsText.text = TextManager.CountOfLapsCar2 + "/" + TextManager.MaxCountOfLaps;

           //Cheking count of laps
           if (TextManager.CountOfLapsCar2 == TextManager.MaxCountOfLaps + 1)
           {
                TextManager.CountOfLapsCar2 = TextManager.MaxCountOfLaps;
                textManager.car2LapsText.text = TextManager.CountOfLapsCar2 + "/" + TextManager.MaxCountOfLaps;
                textManager.StopGame();
           }
        }


    }
}
