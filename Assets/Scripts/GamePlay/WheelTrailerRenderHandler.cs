using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WheelTrailerRenderHandler script // Process
/// wheel trail on cars
/// </summary>
public sealed class WheelTrailerRenderHandler : MonoBehaviour
{ 
    private TrailRenderer _trailRenderer;
    private TopDownCarController _topDownController;

    // Saving TrailRender and TopDownController Script and Setting emmiting
    private void Awake()
    {
        _topDownController = GetComponentInParent<TopDownCarController>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();

        _trailRenderer.emitting = false;
    }

    //Checking if we can TireScreeching or not
    private void Update()
    {
        _trailRenderer.emitting = _topDownController.IsTireScreeching(out float lateralvelocity, out bool IsBraking);
    }
}
