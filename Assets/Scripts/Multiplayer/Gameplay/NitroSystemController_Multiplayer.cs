using System.Collections;
using UnityEngine;
using Mirror;

public sealed class NitroSystemController_Multiplayer : NetworkBehaviour
{
    [SyncVar] private bool _isNitroActive = false;  // Synced across clients
    private bool _canNitroBeUsed = true;

    public bool IsNitroActive => _isNitroActive;

    [SerializeField] private KeyCode nitroActivationButton;
    [SerializeField] private float nitroDuration;
    [SerializeField] private float nitroCoolDownTime;

    [SerializeField] private ParticleSystem nitroParticleSystem;

    void Update()
    {
        if (!isLocalPlayer) return; // Ensure only local player triggers nitro
        
        if (Input.GetKeyDown(nitroActivationButton) && _canNitroBeUsed)
        {
            CmdActivateNitro();
        }
    }

    [Command]
    private void CmdActivateNitro()
    {
        if (!_canNitroBeUsed) return;

        _isNitroActive = true;
        _canNitroBeUsed = false;

        RpcPlayNitroEffects(true);

        StartCoroutine(NitroCoroutine());
    }

    private IEnumerator NitroCoroutine()
    {
        yield return new WaitForSeconds(nitroDuration);

        _isNitroActive = false;
        RpcPlayNitroEffects(false);

        yield return new WaitForSeconds(nitroCoolDownTime);
        _canNitroBeUsed = true;
    }

    [ClientRpc]
    private void RpcPlayNitroEffects(bool isActive)
    {
        if (isActive)
        {
            nitroParticleSystem.Play();
        }
        else
        {
            nitroParticleSystem.Stop();
        }
    }
}
