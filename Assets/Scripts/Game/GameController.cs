using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviour
{
    private PhotonView photonView;
    private GameSM gameSM;
    void Awake()
    {
        photonView = GetComponent<PhotonView>();
        gameSM = GetComponent<GameSM>();
    }
    public void StartGame()
    {
        photonView.RPC("RPC_StartGame", RpcTarget.All);
    }
    [PunRPC]
    public void RPC_StartGame()
    {
        gameSM.ChangeState(gameSM.startGameState);
    }
}
