using UnityEngine;

public class CarCameraControllerCar1 : CarCameraController
{
    private GameObject _car;

    void Start()
    {
        _car = GameObject.FindWithTag("Car1");
        _camera.Follow = _car.transform;
        _camera.LookAt = _car.transform;

        _rb = _car.GetComponent<Rigidbody2D>();
        _topDownCarController = _car.GetComponent<TopDownCarController>();
    }
}
