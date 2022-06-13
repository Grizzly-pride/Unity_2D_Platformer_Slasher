using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnLedgeState : PlayerState
{
    private Vector2 detectedPos;

    private Vector2 pointAngleLedge;
    private bool isTouchingLedge;
    public PlayerOnLedgeState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        player.SetVelocityZero();
        pointAngleLedge = player.GetLedgePointAngle();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isTouchingLedge = player.CheckIfLedge();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;


}

