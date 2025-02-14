using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CarSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _car1SpawningPosition;
    [SerializeField] private Vector2 _car2SpawningPosition;

    private void Awake()
    {
        Instantiate(ChooseCar1Menu.ChoosedCar , _car1SpawningPosition , Quaternion.identity);
        Instantiate(ChooseCar2Menu.ChoosedCar , _car2SpawningPosition , Quaternion.identity);
    }
}
