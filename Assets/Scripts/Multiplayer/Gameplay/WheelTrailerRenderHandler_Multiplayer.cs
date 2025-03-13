using UnityEngine;
using Mirror;

public sealed class WheelTrailerRenderHandler_Multiplayer : NetworkBehaviour
{
    private TrailRenderer _trailRenderer;
    private TopDownCarController_Multiplayer _topDownController;
    private bool _isEmitting = false;

    private void Awake()
    {
        _topDownController = GetComponentInParent<TopDownCarController_Multiplayer>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        _trailRenderer.emitting = false;
    }

    private void Update()
    {
        if (!isLocalPlayer) return; // Only local player checks for skidding

        bool shouldEmit = _topDownController.IsTireScreeching(out float lateralVelocity, out bool isBraking);
        
        if (shouldEmit != _isEmitting) // Only update if there's a change
        {
            _isEmitting = shouldEmit;
            CmdSyncSkidmarks(_isEmitting);
        }
    }

    [Command] 
    private void CmdSyncSkidmarks(bool shouldEmit)
    {
        RpcShowSkidmarks(shouldEmit);
    }

    [ClientRpc]
    private void RpcShowSkidmarks(bool shouldEmit)
    {
        _trailRenderer.emitting = shouldEmit;
    }
}
