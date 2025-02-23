using UnityEngine;

/// <summary>
/// TrafficLightTextMenu script // Shows before game and give to players time
/// to get ready before race
/// </summary>
public class TrafficLightTextMenu : MenuManager
{
    [SerializeField] private GameObject HUD;
    private GameObject _car1;
    private GameObject _car2;

    private CarInputHandler _carInputHandler;
    private CarInputHandler2 _carInputHandler2;

    Timer trafficLightTimer;

    /// <summary>
    /// Disabling cars and HUD and setting Timer
    /// </summary>
    void Start()
    {
        _car1 = GameObject.FindGameObjectWithTag("Car1");
        _car2 = GameObject.FindGameObjectWithTag("Car2");

        _carInputHandler = _car1.GetComponent<CarInputHandler>();
        _carInputHandler2 = _car2.GetComponent<CarInputHandler2>();

        //Disabling HUD and cars
        HUD.SetActive(false);
        _initializedTrafficLightTextMenu = true;

        _carInputHandler.enabled = false;
        _carInputHandler2.enabled = false;

        //Setting Start timer
        trafficLightTimer = gameObject.AddComponent<Timer>();
        trafficLightTimer.Duration = 3f;

        trafficLightTimer.OnTimerFinished += EnableHUDAndCars;
        trafficLightTimer.Run();
    }

        /// <summary>
    /// Method called when the timer finishes.
    /// </summary>
    private void EnableHUDAndCars()
    {
        HUD.SetActive(true);
        _initializedTrafficLightTextMenu = false;

        _carInputHandler.enabled = true;
        _carInputHandler2.enabled = true;
        
        Destroy(trafficLightTimer);
    }
}
