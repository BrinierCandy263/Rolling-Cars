using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class ChooseCar2Menu : MenuManager
{
    [SerializeField] private List<GameObject> carOptions;

    private static GameObject _choosedCar;
    public static GameObject ChoosedCar {get => _choosedCar;}

    public void HandleChooseButton(int choosedCarIndex)
    {
        Debug.Log(choosedCarIndex);
        _choosedCar = carOptions[choosedCarIndex];
    }

    public void HandleSelectButton()
    {
        MenuManager.SwitchToScene(MenuName.MapSelector);
    }
}
