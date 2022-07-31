using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameSM : StateMachine
{
    public GameController gameController;
    [HideInInspector] public WaitForStartState waitForStartState;
    [HideInInspector] public StartGameState startGameState;
    [HideInInspector] public ResultState resultState;
    internal int gameRound;
    public Dictionary<string, string> responses;
    void Awake()
    {
        responses = new Dictionary<string, string>();
        gameController = GetComponent<GameController>();
        waitForStartState = new WaitForStartState(this);
        startGameState = new StartGameState(this);
        resultState = new ResultState(this);
        gameRound = 0;
    }
    protected override BaseState GetInitialState()
    {
        return waitForStartState;
    }
}
