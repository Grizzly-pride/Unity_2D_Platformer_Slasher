using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnLedgeState : PlayerState
{
    private Vector2 anglePos;
    protected Vector2 startPos;
    protected Vector2 endPos;

    private float startPosX;
    private float startPosY;
    private float endPosX;
    private float endPosY;
    private float defaultContactOffset;

    private bool isHanging;
    private bool isClimbing;

    private int yInput;
    private bool jumpInput;

    
    public PlayerOnLedgeState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        player.WallJumpState.DetermineWallJumpDerection(player.CheckIfLedge());
        player.JumpState.ResetAmountOfJumpsLeft();

        player.SetVelocityZero();

        defaultContactOffset = Physics2D.defaultContactOffset;

        startPosX = anglePos.x - (player.BodyCollider.size.x / 2 + defaultContactOffset) * player.FacingDirection;
        startPosY = anglePos.y - (player.BodyCollider.size.y / 2) - player.BodyCollider.offset.y;
        startPos.Set(startPosX, startPosY);

        endPosX = anglePos.x + (player.BodyCollider.size.x) * player.FacingDirection;
        endPosY = anglePos.y + (player.BodyCollider.size.y / 2 + defaultContactOffset) - player.BodyCollider.offset.y;
        endPos.Set(endPosX, endPosY);

        player.transform.position = startPos;
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        
        if (isAnimationFinished)
        {

            player.transform.position = endPos;

            if (player.CheckIfRoof())
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
            else
            {
                stateMachine.ChangeState(player.StandUpState);
            }
            
        }
        else
        {
            yInput = player.InputController.NormInputY;
            jumpInput = player.InputController.JumpInput;

            player.SetVelocityZero();
            player.transform.position = startPos;

            if (yInput.Equals(1) && isHanging && !isClimbing)
            {
                
                isClimbing = true;
                player.Animator.SetBool("climbLedge", true);
            }
            else if (yInput.Equals(-1) && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }
            else if (jumpInput && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.WallJumpState);
            }
            
        }
        
        player.Animator.SetInteger("amountJump", player.JumpState.AmountOfJumpsLeft);
    }

    public override void Exit()
    {
        base.Exit();
        
        isHanging = false;

        if (isClimbing)
        {                    
            isClimbing = false;            
        }
        
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        player.Animator.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        isHanging = true;   
    }



    protected void HoldPosition()
    {
        startPos.Set(startPosX, startPosY);
        player.transform.position = startPos;
    }

    public void SetAnglePosition(Vector2 pos) => anglePos = pos;


}

