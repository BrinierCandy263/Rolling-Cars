using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Steamworks;
using UnityEngine.UI;
using UnityEditor;

public class SteamLobby : MonoBehaviour
{
    public static SteamLobby Instance;

    protected Callback<LobbyCreated_t> LobbyCreated;
    protected Callback<GameLobbyJoinRequested_t> JoinRequest;
    protected Callback<LobbyEnter_t> LobbyEnter;

    public static ulong CurrentLobbyID;

    private const string HostAdressKey = "HostAdress";
    private CustomNetworkManager _customNetworkManager;

    public GameObject hostButton;
    public Text lobbyNameText;

    private void Start()
    {
        if(!SteamManager.Initialized) return; 
        if(Instance == null) Instance = this;

        _customNetworkManager = GetComponent<CustomNetworkManager>();
        LobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        JoinRequest = Callback<GameLobbyJoinRequested_t>.Create(OnJoinRequest);
        LobbyEnter = Callback<LobbyEnter_t>.Create(OnLobbyEntered);

    }

    public void HostLobby()
    {
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly , _customNetworkManager.maxConnections);
    }

    private void OnLobbyCreated(LobbyCreated_t callback)
    {
        if(callback.m_eResult != EResult.k_EResultOK) return;
        Debug.Log("Lobby Created!");

        _customNetworkManager.StartHost();
        SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), HostAdressKey , SteamUser.GetSteamID().ToString());
        SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "name"  , SteamFriends.GetPersonaName().ToString() + " Lobby");

    }

    private void OnJoinRequest(GameLobbyJoinRequested_t callBack)
    {
        Debug.Log("Request to join lobby");
        SteamMatchmaking.JoinLobby(callBack.m_steamIDLobby);
    }

    private void OnLobbyEntered(LobbyEnter_t callback)
    {
        hostButton.SetActive(false);
        CurrentLobbyID = callback.m_ulSteamIDLobby;
        lobbyNameText.gameObject.SetActive(true);
        lobbyNameText.text = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby) , "name");
        if(NetworkServer.active) return;

        _customNetworkManager.networkAddress = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby) , HostAdressKey);
        _customNetworkManager.StartClient();
    }
}
