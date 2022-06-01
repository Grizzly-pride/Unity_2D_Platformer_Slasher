using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleOnWallState : PlayerOnWallState
{
    public PlayerIdleOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    private bool jumpInput;
    private Vector2 holdPosition;

    public override void DoChecks()
    {
        base.DoChecks();
       
    }

    public override void Enter()
    {
        base.Enter();
        //holdPosition.y = player.transform.position.y;
        //HoldPosition();
        player.SetPhysicsMaterial(data.frictionMaterial);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            //HoldPosition();
            Debug.Log(player.FacingDirection);
            player.SetVelocityX(data.airMoveX * player.FacingDirection);

            jumpInput = player.InputController.JumpInput;

            if (jumpInput)
            {
                stateMachine.ChangeState(player.WallJumpState);
            }

        }

    }


    /*

    private void HoldPosition()
    {
        holdPosition.x = player.CurrentMotion.x;
        player.transform.position = holdPosition;
        player.SetVelocityZero();

    }

    */

}
