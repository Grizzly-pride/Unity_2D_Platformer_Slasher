using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerInAirState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        SetAactivatedCheckGround();

    }

    public override void Exit()
    {
        base.Exit();
   
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();       
                         
        if (dobleJumpInput)
        {
            player.InputController.UseJumpInput();
            stateMachine.ChangeState(player.DoubleJumpState);              
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
