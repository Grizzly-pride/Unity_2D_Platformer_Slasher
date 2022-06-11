using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{

    private int xInput;
    protected bool JumpInput;
    private bool isGrounded;
    private bool isFall;
    private bool isTouchingGrabWall;
    private float fallingSpeed;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)  
    {
     
    }

    public override void Enter()
    {
        base.Enter();
        isFall = false;   
        player.wasCrouch = false;
        player.JumpState.DecreaseAmountOfJumpsLeft();
        player.SetColliderHeight(data.standColiderHeight);
        player.SetGravityOn();
        player.SetPhysicsMaterial(data.noFrictionMaterial);

    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isTouchingGrabWall = player.CheckIfWall();
        CheckFallingSpeed();
        ChechIfFall();
    }

    public override void Exit()
    {
        base.Exit();
       
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        JumpInput = player.InputController.JumpInput;
        xInput = player.InputController.NormInputX;

        
        if (isTouchingGrabWall && isFall)
        {
            stateMachine.ChangeState(player.LandingOnWallState);
        }

        else if(JumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        
        else if (isGrounded && isFall)
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
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(data.airMoveX * xInput);

            SetAnimation();
        }
    }

    private void SetAnimation()
    {
        player.Animator.SetFloat("yVelocity", player.CurrentMotion.y);
        player.Animator.SetInteger("amountJump", player.JumpState.AmountOfJumpsLeft);
    }

    private void ChechIfFall()
    {
        if(player.CurrentMotion.y < 0.01f && !isFall)
        {           
            isFall = true;
        }
    }

    private void CheckFallingSpeed()
    {
        if (!isGrounded && player.CurrentMotion.y <= -0.01f)
        {            
            fallingSpeed = player.CurrentMotion.y;
        }
    }
}

