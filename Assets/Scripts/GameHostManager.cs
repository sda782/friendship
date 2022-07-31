using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHostManager : MonoBehaviourPunCallbacks
{
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
