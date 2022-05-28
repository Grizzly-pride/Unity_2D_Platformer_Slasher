using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int xInput;
    protected bool dobleJumpInput;
    private bool isGrounded;
    private bool deactCheckGround;
    private bool isSlope;
    private bool isTouchingGrabWall;
    private float fallingSpeed;
    

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)  
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.wasCrouch = false;
        player.SetColliderHeight(data.standColiderHeight);
        player.SetPhysicsMaterial(data.noFrictionMaterial);
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isSlope = player.CheckIfSlope();
        isTouchingGrabWall = player.CheckIfWall();
        CheckFallingSpeed();

    }

    public override void Exit()
    {
        base.Exit();
       
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        dobleJumpInput = player.InputController.JumpInput;
        xInput = player.InputController.NormInputX;

        player.CheckIfShouldFlip(xInput);
        player.SetVelocityX(data.airMoveX * xInput);


        if (isTouchingGrabWall && CheckEqualityXposition())
        {
            stateMachine.ChangeState(player.LandingOnWallState);
        }


        else if (!deactCheckGround)
        {

            if (isGrounded && !isSlope && player.CurrentMotion.y <= 0.01f || isGrounded && isSlope)
            {
                if (fallingSpeed <= data.thresholdHardLanding)
                {
                    stateMachine.ChangeState(player.HardLanding);
                }
                else if (fallingSpeed > data.thresholdHardLanding)
                {
                    stateMachine.ChangeState(player.LandState);
                }
            }
        }
        

    }

    private void CheckFallingSpeed()
    {
        if (!isGrounded && player.CurrentMotion.y <= -0.01f)
        {
            fallingSpeed = player.CurrentMotion.y;
        }
    }

    private bool CheckEqualityXposition()
    {
        if (player.CurrentPos.x == player.LastPos.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void SetDeactivatedCheckGround() => deactCheckGround = true;
    protected void SetAactivatedCheckGround() => deactCheckGround = false;


}
