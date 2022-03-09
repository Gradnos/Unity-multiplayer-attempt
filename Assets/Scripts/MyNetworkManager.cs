using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("Server Started");
    }


    public override void OnStopServer()
    {
        base.OnStopServer();
        Debug.Log("Server Stopped");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect();
        Debug.Log("Connected to Server");
    }



    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect();
        Debug.Log("Disconnected from Server");
    }
}
