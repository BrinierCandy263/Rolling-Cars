using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
    public static CustomNetworkManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }


    public override void OnServerSceneChanged(string sceneName)
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint").OrderBy(x => x.name).ToArray();
        for(int i = 0; i < NetworkServer.connections.Count; i++)
        {
            SpawnPlayer(NetworkServer.connections[i] , spawnPoints[i]);
        }
    }

    private void SpawnPlayer(NetworkConnectionToClient conn , GameObject spawnPoint)
    {
        GameObject player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);
    }

    private Transform GetSpawnPoint() {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        return spawnPoints.Length > 0 ? spawnPoints[Random.Range(0, spawnPoints.Length)].transform : null;
    }

    [Server]
    public void StartGame(int levelNumber) {
            ServerChangeScene($"Level{levelNumber}_Multiplayer");
    }
}
