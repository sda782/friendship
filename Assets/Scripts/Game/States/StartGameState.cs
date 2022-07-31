using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class StartGameState : BaseState
{
    private GameSM gameStateMachine;
    private Text result;
    public StartGameState(GameSM stateMachine) : base(stateMachine)
    {
        gameStateMachine = stateMachine;
        result = GameObject.Find("Result").GetComponent<Text>();
    }
    public override void Enter()
    {
        result.text = "Start Game";
    }
}
