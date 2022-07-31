using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameSM : StateMachine
{
    public GameController gameController;
    [HideInInspector] public WaitForStartState waitForStartState;
    [HideInInspector] public StartGameState startGameState;
    internal int gameRound;
    void Awake()
    {
        gameController = GetComponent<GameController>();
        waitForStartState = new WaitForStartState(this, gameController);
        startGameState = new StartGameState(this);
        gameRound = 0;
    }
    protected override BaseState GetInitialState()
    {
        return waitForStartState;
    }
}
