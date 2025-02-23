using UnityEngine;

public sealed class CarSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _car1SpawningPosition;
    [SerializeField] private Vector2 _car2SpawningPosition;

    private void Awake()
    {
        GameObject car1 = Instantiate(ChooseCarMenu1.ChoosedCar , _car1SpawningPosition , Quaternion.identity);
        GameObject car2 = Instantiate(ChooseCarMenu2.ChoosedCar , _car2SpawningPosition , Quaternion.identity);
    }
}
