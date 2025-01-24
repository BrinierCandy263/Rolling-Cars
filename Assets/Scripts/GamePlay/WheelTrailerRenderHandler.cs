using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WheelTrailerRenderHandler script // Process
/// wheel trail on cars
/// </summary>
public class WheelTrailerRenderHandler : MonoBehaviour
{ 
    TrailRenderer trailRenderer;
    TopDownCarController topDownController;

    // Saving TrailRender and TopDownController Script and Setting emmiting
    void Awake()
    {
        topDownController = GetComponentInParent<TopDownCarController>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();

        trailRenderer.emitting = false;
    }

    //Checking if we can TireScreeching or not
    void Update()
    {
        trailRenderer.emitting = topDownController.IsTireScreeching(out float lateralvelocity, out bool IsBraking);
    }
}
