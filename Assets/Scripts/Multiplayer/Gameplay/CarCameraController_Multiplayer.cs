using UnityEngine;
using Cinemachine;
using Mirror;

public class CarCameraController_Multiplayer : NetworkBehaviour
{
    private CinemachineVirtualCamera _camera;
    private Rigidbody2D _rb;
    private TopDownCarController_Multiplayer _topDownCarController;

    [SerializeField] private float minFOV;
    [SerializeField] private float maxFOV;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        _camera = FindObjectOfType<CinemachineVirtualCamera>();
        _rb = GetComponent<Rigidbody2D>();
        _topDownCarController = GetComponent<TopDownCarController_Multiplayer>();
        
        if(_camera != null) _camera.Follow = transform;
    }

    void Update()
    {
        float speedNormalized = Mathf.Clamp01(_rb.velocity.magnitude / _topDownCarController.MaxSpeed);
        float targetFOV = Mathf.Lerp(minFOV, maxFOV, speedNormalized);

        // Smoothly adjust the camera's FOV
        _camera.m_Lens.OrthographicSize = Mathf.Lerp(_camera.m_Lens.OrthographicSize, targetFOV, Time.deltaTime * 3f);
    }
}
