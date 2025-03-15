using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;
using Steamworks;

public class NetworkGameButtons : MonoBehaviour
{
    [SerializeField] private Button _inviteFriendButton;
    [SerializeField] private Text numberOfPlayersInLobbyText;
    [SerializeField] private Text errorMessageText;

    private void Update()
    {
        _inviteFriendButton.interactable = NetworkServer.active;
        numberOfPlayersInLobbyText.text = $"{NetworkServer.connections.Count} player(s) in lobby";
    }

    public void StartGame(int levelNumber)
    {
        
        if (NetworkServer.connections.Count == 1) 
        {
            StartCoroutine(ShowTextCoroutine("You don't have enough players , invite someone!" , 3f));
            return;
        }
        
        

        if (NetworkServer.active) CustomNetworkManager.Instance.StartGame(levelNumber);
    }

    public void InviteFriend()
    {
        if (SteamManager.Initialized) SteamFriends.ActivateGameOverlayInviteDialog(new CSteamID(SteamLobby.CurrentLobbyID));
    }
    
    private IEnumerator ShowTextCoroutine(string message, float duration)
    {
        errorMessageText.text = message;
        errorMessageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        errorMessageText.gameObject.SetActive(false);
    }
}