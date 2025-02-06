using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public sealed class CarCameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    private Rigidbody2D _rb;
    private TopDownCarController _topDownCarController;

    [SerializeField] private GameObject _followingObject;
    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;

    void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        _rb = _followingObject.GetComponent<Rigidbody2D>();
        _topDownCarController = _followingObject.GetComponent<TopDownCarController>();
    }

    void Update()
    {
        float speedNormalized = Mathf.Clamp01(_rb.velocity.magnitude / _topDownCarController.MaxSpeed);
        float targetFOV = Mathf.Lerp(minFOV, maxFOV, speedNormalized);

        // Smoothly adjust the camera's FOV
        _camera.m_Lens.OrthographicSize = Mathf.Lerp(_camera.m_Lens.OrthographicSize, targetFOV, Time.deltaTime * 3f);
    }
}
