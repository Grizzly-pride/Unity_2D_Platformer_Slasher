using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int xInput;
    protected bool dobleJumpInput;
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
        player.SetColliderHeight(data.standColiderHeight);
        player.SetGravityOn();
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

        dobleJumpInput = player.InputController.JumpInput;
        xInput = player.InputController.NormInputX;

        
        if (isTouchingGrabWall)
        {
            stateMachine.ChangeState(player.IdleOnWallState);

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
            player.Animator.SetFloat("yVelocity", player.CurrentMotion.y);            
 
        }
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
