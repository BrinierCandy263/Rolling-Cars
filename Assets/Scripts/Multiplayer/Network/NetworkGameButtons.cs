using UnityEngine;
using UnityEngine.UI;
using Mirror;
using Steamworks;

public class NetworkGameButtons : MonoBehaviour
{
    [SerializeField] private Button _inviteFriendButton;

    private void Update()
    {
        _inviteFriendButton.interactable = NetworkServer.active; 
    }

    public void StartGame(int levelNumber)
    {
        if (NetworkServer.active) CustomNetworkManager.Instance.StartGame(levelNumber);
    }

    public void InviteFriend()
    {
        if (SteamManager.Initialized) SteamFriends.ActivateGameOverlayInviteDialog(new CSteamID(SteamLobby.CurrentLobbyID));
    }
}