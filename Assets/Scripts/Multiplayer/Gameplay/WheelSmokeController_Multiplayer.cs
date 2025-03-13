using UnityEngine;
using Mirror;

public sealed class WheelSmokeController_Multiplayer : NetworkBehaviour
{
    private float _particleEmissionRate = 0f;
    private TopDownCarController_Multiplayer _topDownCarController;
    private ParticleSystem _particleSystem;
    private ParticleSystem.EmissionModule _particleSystemEmissionModule;

    void Awake()
    {
        _topDownCarController = GetComponentInParent<TopDownCarController_Multiplayer>();
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystemEmissionModule = _particleSystem.emission;
        _particleSystemEmissionModule.rateOverTime = 0;
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        _particleEmissionRate = Mathf.Lerp(_particleEmissionRate, 0, Time.deltaTime * 5);
        
        if (_topDownCarController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            _particleEmissionRate = isBraking ? 30 : Mathf.Abs(lateralVelocity) * 2;
        }

        CmdSyncSmokeEffect(_particleEmissionRate);
    }

    [Command]  // Command to send smoke data to the server
    private void CmdSyncSmokeEffect(float emissionRate)
    {
        RpcShowSmoke(emissionRate);
    }

    [ClientRpc]  // RPC to show the smoke effect on all clients
    private void RpcShowSmoke(float emissionRate)
    {
        _particleSystemEmissionModule.rateOverTime = emissionRate;
    }
}
