using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class WaitForStartState : BaseState
{
    private GameSM gameStateMachine;
    private GameController gameController;
    private Text result;
    public WaitForStartState(GameSM gameSM, GameController gameController) : base(gameSM)
    {
        gameStateMachine = gameSM;
        this.gameController = gameController;
        result = GameObject.Find("Result").GetComponent<Text>();
    }
    public override void Enter()
    {
        base.Enter();
        result.text = "Wait for start";
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (PhotonNetwork.IsMasterClient && Input.GetKeyDown(KeyCode.Space))
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            gameController.StartGame();
        }
    }
}
