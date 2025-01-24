using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CarInputHandler2 script // Setting
/// control of second car
/// </summary>
public class CarInputHandler2 : TopDownCarController
{
    void Update()
    {
        //Setting control by SetInputVector Method
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal2");
        inputVector.y = Input.GetAxis("Vertical2");

        SetInputVector(inputVector);
    }
}
