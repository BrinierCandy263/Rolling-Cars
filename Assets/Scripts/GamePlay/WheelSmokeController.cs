using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WheelSmokeController : MonoBehaviour
{
    private float _particleEmissionRate = 0f;

    private TopDownCarController _topDownCarController;

    private ParticleSystem _particleSystem;
    private ParticleSystem.EmissionModule _particleSystemEmissionModule;

    void Awake()
    {
        _topDownCarController = GetComponentInParent<TopDownCarController>();
        _particleSystem = GetComponent<ParticleSystem>();

        _particleSystemEmissionModule = _particleSystem.emission;
        _particleSystemEmissionModule.rateOverTime = 0;
    }

    void Update()
    {
        // Reduce the particles over time.
        _particleEmissionRate = Mathf.Lerp(_particleEmissionRate, 0, Time.deltaTime * 5);
        _particleSystemEmissionModule.rateOverTime = _particleEmissionRate;

        if (_topDownCarController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            // If the car tires are screeching then we'll emit smoke. If the player is braking then emit a lot of smoke.
            // If the player is drifting -> we'll emit smoke based on how much the player is drifting.
            _particleEmissionRate = isBraking ? 30 : Mathf.Abs(lateralVelocity) * 2;
        }
    }
}
