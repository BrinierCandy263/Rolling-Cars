using UnityEngine;

/// <summary>
/// CarInputHandler script // Setting
/// control of first car
/// </summary>
public class CarInputHandler : TopDownCarController
{
    
    private void Update()
    {
        //Setting control by SetInputVector Method
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        SetInputVector(inputVector);
    }
    
}
