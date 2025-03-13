using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public sealed class ChooseCarMenu_Multiplayer : MonoBehaviour
{
 [SerializeField] private List<GameObject> carOptions;

    [SerializeField] private Slider driftSlider;
    [SerializeField] private Slider accelerationSlider;
    [SerializeField] private Slider turnFactorSlider;
    [SerializeField] private Slider nitroBoost;
    [SerializeField] private Image carImage;

    private int _choosedCarIndex = 0;

    public void HandleChooseButton(int choosedCarIndex)
    {
        _choosedCarIndex = choosedCarIndex;
        GameObject choosedCar = carOptions[choosedCarIndex];

        SpriteRenderer carSpriteRenderer = choosedCar.GetComponent<SpriteRenderer>();
        TopDownCarController_Multiplayer carInputHandler = GetCarInputHandler(choosedCar);

        carImage.sprite = carSpriteRenderer.sprite;
        driftSlider.value = carInputHandler.DriftFactor;

        accelerationSlider.value = carInputHandler.AccelerationFactor;
        turnFactorSlider.value = carInputHandler.TurnFactor;
        
        nitroBoost.value = carInputHandler.NitroBoost;

    }

    private TopDownCarController_Multiplayer GetCarInputHandler(GameObject choosedCar)
    {
        return choosedCar.GetComponent<CarInputHandler_Multiplayer>();
    }

    public void HandleSelectButton()
    {
        PlayerPrefs.SetInt("SelectedCar" , _choosedCarIndex);
        MenuManager.SwitchToScene(MenuName.Car2ChooseMenu);
    }
}
