using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TopDownCarController script // Process all
/// physics and control of cars and 
/// </summary>
public class TopDownCarController : MonoBehaviour
{
    [SerializeField] private float _driftFactor;
    [SerializeField] private float _accelerationFactor;
    [SerializeField] private float _turnFactor;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _maxSpeedForNitro;
    [SerializeField] private float _nitroBoost;

    public float MaxSpeed {get => _maxSpeed;}

    private NitroSystemController _nitroSystemController;

    private float _accelerationInput = 0;
    private float _steeringInput = 0;
    private float _rotationAngle = 0;
    private float _velocityVsUp = 0;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _nitroSystemController = GetComponent<NitroSystemController>();
    }

    /// <summary>
    /// //Applying all our control methods on a car
    /// </summary>
    private void FixedUpdate()
    { 
       ApplyEngineForce();
       KillOrthogonalVelocity();
       ApplySteering();        
    }

    /// <summary>
    /// Applying Engine Force on a car
    /// </summary>
    private void ApplyEngineForce()
    {

         // Caculate how much "forward" we are going in terms of the direction of our velocity
        _velocityVsUp = Vector2.Dot(transform.up, _rb.velocity);

        if(_nitroSystemController.IsNitroActive) 
        {
             if (_velocityVsUp > _maxSpeedForNitro && _accelerationInput > 0) return;
            _rb.AddForce(transform.up * _accelerationInput * _accelerationFactor * _nitroBoost, ForceMode2D.Force);
        }

        //Limit so we cannot go faster than the max speed in the "forward" 
        if (_velocityVsUp > _maxSpeed && _accelerationInput > 0) return;

        //Limit so we cannot go faster than the 50% of max speed in the "reverse" direction 
        if (_velocityVsUp < -_maxSpeed * 0.5f && _accelerationInput < 0) return;

        // Limit so we cannot go faster in any direction while accelerating
        if (_rb.velocity.sqrMagnitude > _maxSpeed * _maxSpeed && _accelerationInput > 0) return;

        //Calculate drag
        _rb.drag = _accelerationInput == 0 ? Mathf.Lerp(_rb.drag, 2.3f, Time.fixedDeltaTime * 3f) : 0f;
        
        // Create a force for the engine Vector2D
        Vector2 engineForceVector = transform.up * _accelerationInput * _accelerationFactor;        
        // Аpply force and pushes the car 
        _rb.AddForce(engineForceVector, ForceMode2D.Force);
    }

    /// <summary>
    /// Applying Steering
    /// </summary>
    private void ApplySteering()
    {
        //Limit the cars ability to turn when moving slowly
        float minSpeedBeforeTurningFactor = (_rb.velocity.magnitude / 8f);
        minSpeedBeforeTurningFactor = Mathf.Clamp01(minSpeedBeforeTurningFactor);

        //Update the rotation angle based on input
        _rotationAngle -= _steeringInput * _turnFactor * minSpeedBeforeTurningFactor;

        //Apply steering by rotating the car object
        _rb.MoveRotation(_rotationAngle);
    }

    /// <summary>
    /// Getting Lateral Velocity
    /// </summary>
    /// <returns></returns>
    private float GetLateralVelocity()
    {
        return Vector2.Dot(transform.right, _rb.velocity);
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

        if(_accelerationInput < 0.1f && _velocityVsUp > 15f )
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
    private void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(_rb.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(_rb.velocity, transform.right);

        _rb.velocity = forwardVelocity + rightVelocity * _driftFactor;
    }
    
    /// <summary>
    /// Setting Control in Car Input Handler script
    /// </summary>
    /// <param name="inputVector"></param>
    protected void SetInputVector(Vector2 inputVector)
    {
        _steeringInput = inputVector.x;
        _accelerationInput = inputVector.y;
    }
}




