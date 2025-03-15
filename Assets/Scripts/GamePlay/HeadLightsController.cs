using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLightsController : MonoBehaviour
{
    [SerializeField] private GameObject _leftHeadLight;
    [SerializeField] private GameObject _rightHeadLight;
    [SerializeField] private GameObject _leftlight;
    [SerializeField] private GameObject _rightlight;
    [SerializeField] private KeyCode keyCode;

    private bool _isLightsActive = false;

    private void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            _isLightsActive = !_isLightsActive;

            _leftHeadLight.SetActive(_isLightsActive);
            _rightHeadLight.SetActive(_isLightsActive);

            _leftlight.SetActive(_isLightsActive);
            _rightlight.SetActive(_isLightsActive);
        }
    }

}
