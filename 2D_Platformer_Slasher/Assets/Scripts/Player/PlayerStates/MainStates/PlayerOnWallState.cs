using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : PlayerState
{
    public PlayerOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    protected bool isTouchingGrabWall;


    public override void DoChecks()
    {
        base.DoChecks();

        isTouchingGrabWall = player.CheckIfWall();


    }

    public override void Enter()
    {
        base.Enter();


    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();



    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }



}
