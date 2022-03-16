using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JoinGameMenu : MonoBehaviour
{
    [SerializeField] private MyNetworkManager networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPanel = null;
    [SerializeField] private TMP_InputField ipAddressInputField = null;
    [SerializeField] private Button joinButton = null;

    private void OnEnable()
    {
        MyNetworkManager.OnClientConnected += HandleClientConnected;
        MyNetworkManager.OnClientDisconnected += HandleClientDisconnected;
    }
    private void OnDisable()
    {
        MyNetworkManager.OnClientConnected -= HandleClientConnected;
        MyNetworkManager.OnClientDisconnected -= HandleClientDisconnected;
    }

    public void JoinLobby()
    {
        string ipAddress = ipAddressInputField.text;

        networkManager.networkAddress = ipAddress;
        networkManager.StartClient();

        joinButton.interactable = false;
    }

    private void HandleClientConnected()
    {
        joinButton.interactable = true;

        gameObject.SetActive(false);
        landingPanel.SetActive(false);
    }

    public void HandleClientDisconnected()
    {
        joinButton.interactable = true;
    }



}
