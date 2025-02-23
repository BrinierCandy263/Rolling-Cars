using System.Collections;
using UnityEngine;

public sealed class NitroSystemController : MonoBehaviour
{
    private bool _isNitroActive = false;
    private bool _canNitroBeUsed = true;

    public bool IsNitroActive {get => _isNitroActive; }

    [SerializeField] private KeyCode nitroActivationButton;
    [SerializeField] private float nitroDuration;
    [SerializeField] private float nitroCoolDownTime;
 
    [SerializeField] private ParticleSystem nitroParticleSystem;

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(nitroActivationButton) && _canNitroBeUsed) StartCoroutine(ActivateNitro());
    }

    private IEnumerator ActivateNitro()
    {
        _isNitroActive = true;
        _canNitroBeUsed = false;

        nitroParticleSystem.Play();

        yield return new WaitForSeconds(nitroDuration);

        // Revert to original speed
        _isNitroActive = false;
        nitroParticleSystem.Stop();

        // Start cooldown timer
        yield return new WaitForSeconds(nitroCoolDownTime);

        _canNitroBeUsed = true;
    }
}
