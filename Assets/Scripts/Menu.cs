using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }
    public void OnClick_CreateGame()
    {
        RoomOptions ro = new RoomOptions() { MaxPlayers = 3 };
        PhotonNetwork.NickName = "sae#" + Random.Range(0, 9999);
        PhotonNetwork.CreateRoom("abc", ro, TypedLobby.Default);
    }
    public void OnClick_JoinGame()
    {
        PhotonNetwork.NickName = "sae#" + Random.Range(0, 9999);
        PhotonNetwork.JoinRoom("abc");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server " + cause);
    }
}
