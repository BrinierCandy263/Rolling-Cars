using Mirror;
using UnityEngine;

public class HeadLightsController_Multiplayer : NetworkBehaviour
{
    [SerializeField] private GameObject _leftHeadLight;
    [SerializeField] private GameObject _rightHeadLight;
    [SerializeField] private GameObject _leftlight;
    [SerializeField] private GameObject _rightlight;
    [SerializeField] private KeyCode keyCode; // Default key for lights

    [SyncVar(hook = nameof(OnLightsChanged))]
    private bool _isLightsActive = false;

    private void Update()
    {
        if (!isLocalPlayer) return; // Ensure only the local player processes input

        if (Input.GetKeyDown(keyCode))
        {
            CmdToggleLights();
        }
    }

    [Command] // Called on client, runs on server
    private void CmdToggleLights()
    {
        _isLightsActive = !_isLightsActive; // Update SyncVar
    }

    private void OnLightsChanged(bool oldValue, bool newValue)
    {
        _leftHeadLight.SetActive(newValue);
        _rightHeadLight.SetActive(newValue);
        _leftlight.SetActive(newValue);
        _rightlight.SetActive(newValue);
    }
}