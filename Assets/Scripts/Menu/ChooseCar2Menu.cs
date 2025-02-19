using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class ChooseCar2Menu : MenuManager
{
    [SerializeField] private List<GameObject> carOptions;
    [SerializeField] private Image carImage;

    private static GameObject _choosedCar = null;
    public static GameObject ChoosedCar {get => _choosedCar;}

    public void HandleChooseButton(int choosedCarIndex)
    {
        carImage.sprite = carOptions[choosedCarIndex].GetComponent<SpriteRenderer>().sprite;
        _choosedCar = carOptions[choosedCarIndex];
    }

    public void HandleSelectButton()
    {
        if(_choosedCar != null) MenuManager.SwitchToScene(MenuName.MapSelector);
    }
}
