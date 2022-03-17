using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MyNetworkManager networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPanel = null;

    public void HostLobby()
    {
        networkManager.StartHost();
    }

    public void QuitGame()
    {
        print("quitting");
        Application.Quit();
    }
}
