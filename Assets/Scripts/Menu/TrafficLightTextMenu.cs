using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TrafficLightTextMenu script // Shows before game and give to players time
/// to get ready before race
/// </summary>
public class TrafficLightTextMenu : MenuManager
{
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject car1;
    [SerializeField] GameObject car2;

    private CarInputHandler carInputHandler;
    private CarInputHandler2 carInputHandler2;

    Timer trafficLightTimer;

    /// <summary>
    /// Disabling cars and HUD and setting Timer
    /// </summary>
    void Awake()
    {
        Cursor.visible = true;
        carInputHandler = car1.GetComponent<CarInputHandler>();
        carInputHandler2 = car2.GetComponent<CarInputHandler2>();

        //Disabling HUD and cars
        HUD.SetActive(false);
        _initializedTrafficLightTextMenu = true;

        carInputHandler.enabled = false;
        carInputHandler2.enabled = false;

        //Setting Start timer
        trafficLightTimer = gameObject.AddComponent<Timer>();
        trafficLightTimer.Duration = 3f;
        trafficLightTimer.Run();
    }

    /// <summary>
    /// Checking timer and on Hud
    /// </summary>
    void Update()
    {   
        //Checking and activating HUD and cars
        if (trafficLightTimer.Finished)
        {
            HUD.SetActive(true);
            _initializedTrafficLightTextMenu = false;

            carInputHandler.enabled = true;
            carInputHandler2.enabled = true;
        }
    }
}
