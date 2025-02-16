using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarCameraController : MonoBehaviour
{
    protected CinemachineVirtualCamera _camera;
    protected Rigidbody2D _rb;
    protected TopDownCarController _topDownCarController;

    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;

    void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        float speedNormalized = Mathf.Clamp01(_rb.velocity.magnitude / _topDownCarController.MaxSpeed);
        float targetFOV = Mathf.Lerp(minFOV, maxFOV, speedNormalized);

        // Smoothly adjust the camera's FOV
        _camera.m_Lens.OrthographicSize = Mathf.Lerp(_camera.m_Lens.OrthographicSize, targetFOV, Time.deltaTime * 3f);
    }
}
