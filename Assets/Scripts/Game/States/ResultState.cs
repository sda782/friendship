using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResultState : BaseState
{
    private GameSM gameSM;
    private Text result;
    public ResultState(GameSM gameSM) : base(gameSM)
    {
        this.gameSM = gameSM;
        result = GameObject.Find("Result").GetComponent<Text>();
    }
    public override void Enter()
    {
        result.text = "Getting Result";
        Debug.Log(gameSM.responses.First());
    }
}