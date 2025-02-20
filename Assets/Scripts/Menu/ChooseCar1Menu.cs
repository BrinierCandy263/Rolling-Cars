using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public sealed class ChooseCarMenu1 : MonoBehaviour
{
 [SerializeField] private List<GameObject> carOptions;

    [SerializeField] private Slider driftSlider;
    [SerializeField] private Slider accelerationSlider;
    [SerializeField] private Slider turnFactorSlider;
    [SerializeField] private Slider nitroBoost;
    [SerializeField] private Image carImage;

    protected static GameObject _choosedCar = null;
    public static GameObject ChoosedCar {get => _choosedCar;}

    public void HandleChooseButton(int choosedCarIndex)
    {
        _choosedCar = carOptions[choosedCarIndex];
        SpriteRenderer carSpriteRenderer = _choosedCar.GetComponent<SpriteRenderer>();
        TopDownCarController carInputHandler = GetCarInputHandler();

        carImage.sprite = carSpriteRenderer.sprite;
        driftSlider.value = carInputHandler.DriftFactor;
        accelerationSlider.value = carInputHandler.AccelerationFactor;
        turnFactorSlider.value = carInputHandler.TurnFactor;
        nitroBoost.value = carInputHandler.NitroBoost;

    }

    private TopDownCarController GetCarInputHandler()
    {
        return _choosedCar.GetComponent<CarInputHandler>();
    }

    public void HandleSelectButton()
    {
        if(_choosedCar != null) MenuManager.SwitchToScene(MenuName.Car2ChooseMenu);
    }
}
