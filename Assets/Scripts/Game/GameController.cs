using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviourPunCallbacks
{
    private PhotonView _photonView;
    private GameSM gameSM;
    public Dictionary<string, string> responses;
    private ExitGames.Client.Photon.Hashtable _customProps = new ExitGames.Client.Photon.Hashtable();
    void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        gameSM = GetComponent<GameSM>();
        responses = new Dictionary<string, string>();
        gameSM.responses = responses;
    }

    public void SetResponse(string response)
    {
        _customProps["Response"] = response;
        PhotonNetwork.SetPlayerCustomProperties(_customProps);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        responses.Add(targetPlayer.NickName, changedProps["Response"].ToString());
    }

    public void StartGame()
    {
        _photonView.RPC("RPC_StartGame", RpcTarget.All);
    }
    public void GetResult()
    {
        _photonView.RPC("RPC_GetResult", RpcTarget.All);
    }

    //  RPC METHODS
    [PunRPC]
    private void RPC_StartGame()
    {
        gameSM.ChangeState(gameSM.startGameState);
    }
    [PunRPC]
    private void RPC_GetResult()
    {
        gameSM.ChangeState(gameSM.resultState);
    }

}
