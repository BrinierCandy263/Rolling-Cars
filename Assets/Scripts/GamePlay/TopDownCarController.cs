
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TopDownCarController script // Process all
/// physics and control of cars and 
/// </summary>


public class TopDownCarController : MonoBehaviour
{
    [SerializeField] float driftFactor;
    [SerializeField] float accelerationFactor;
    [SerializeField] float turnFactor;
    [SerializeField] float maxSpeed;
    [SerializeField] float nitroBoost;
    
    [SerializeField] ParticleSystemController particleSystemControllerLeftWheel;
    [SerializeField] ParticleSystemController particleSystemControllerRightWheel;


    private float accelerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle = 0;
    private float velocityVsUp = 0;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// //Applying all our control methods on a car
    /// </summary>
    void FixedUpdate()
    { 
       ApplyEngineForce();
       KillOrthogonalVelocity();
       ApplySteering();        
    }

    /// <summary>
    /// Applying Engine Force on a car
    /// </summary>
    void ApplyEngineForce()
    {
        // Create a force for the engine Vector2D
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;
        if(particleSystemControllerLeftWheel.IsNitroActive && particleSystemControllerRightWheel.IsNitroActive) engineForceVector *= nitroBoost;
        
        // Аpply force and pushes the car 
        rb.AddForce(engineForceVector, ForceMode2D.Force);

        // Caculate how much "forward" we are going in terms of the direction of our velocity
        velocityVsUp = Vector2.Dot(transform.up, rb.velocity);

        //Limit so we cannot go faster than the max speed in the "forward" 
        if (velocityVsUp > maxSpeed && accelerationInput > 0) return;

        //Limit so we cannot go faster than the 50% of max speed in the "reverse" direction 
        if (velocityVsUp < maxSpeed * 0.5f && accelerationInput < 0) return;

        // Limit so we cannot go faster in any direction while accelerating
        if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0) return;

        // drag if there is no ascelerationInput so the car stops when the player lets go of the assistant
        if (accelerationInput == 0)
        {
            rb.drag = Mathf.Lerp(rb.drag, 3.0f, Time.fixedDeltaTime * 3f);
        }
        else
        {
            rb.drag = 0f;
        }
    }

    /// <summary>
    /// Applying Steering
    /// </summary>
    void ApplySteering()
    {
        //Limit the cars ability to turn when moving slowly
        float minSpeedBeforeTurningFactor = (rb.velocity.magnitude / 8f);
        minSpeedBeforeTurningFactor = Mathf.Clamp01(minSpeedBeforeTurningFactor);

        //Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeTurningFactor;

        //Apply steering by rotating the car object
        rb.MoveRotation(rotationAngle);
    }

    /// <summary>
    /// Getting Lateral Velocity
    /// </summary>
    /// <returns></returns>
    float GetLateralVelocity()
    {
        return Vector2.Dot(transform.right, rb.velocity);
    }

    /// <summary>
    /// Checking for Screeching 
    /// </summary>
    /// <param name="lateralVelocity"></param>
    /// <param name="IsBraking"></param>
    /// <returns></returns>
    public bool IsTireScreeching(out float lateralVelocity , out bool IsBraking)
    {
        lateralVelocity = GetLateralVelocity();
        IsBraking = false;

        if(accelerationInput < 0.1f && velocityVsUp > 15f )
        {
            IsBraking = true;
            return true;
        }

        if(Mathf.Abs(GetLateralVelocity()) > 10.0f) return true;

        return false;
    }

    /// <summary>
    /// Killing Orthogonal Velocity
    /// </summary>
    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    /// <summary>
    /// Setting Control in Car Input Handler script
    /// </summary>
    /// <param name="inputVector"></param>
    protected void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}



