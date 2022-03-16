using UnityEngine;
using Mirror;
using System;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Events;

public class MyNetworkManager : NetworkManager
{

    [Scene] [SerializeField] private string menuScene = string.Empty;

    [Header("Game")]
    [SerializeField] private GameObject gamePlayer = null;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;

    public override void OnStartServer() => spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();

    public override void OnStartClient()
    {
        var SpawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");

        foreach (var prefab in SpawnablePrefabs)
        {
            NetworkClient.RegisterPrefab(prefab);
        }
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        OnClientConnected?.Invoke();
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();

        OnClientDisconnected?.Invoke();
    }

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        if (numPlayers >= maxConnections)
        {
            conn.Disconnect();
            return;
        }

        print("scene");


        
        this.ServerChangeScene("Game");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject playerInstance = Instantiate(gamePlayer);
        NetworkServer.AddPlayerForConnection(conn, playerInstance.gameObject);
    }
}
