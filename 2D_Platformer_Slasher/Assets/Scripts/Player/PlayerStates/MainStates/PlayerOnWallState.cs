using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : PlayerState
{
    public PlayerOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    protected bool isTouchingGrabWall;

    private Vector2 holdPosition;
    private Vector2 detectPointHit;

    private float posX;
    private float posY;
    private float defaultContactOffset;


    public override void DoChecks()
    {
        base.DoChecks();
        isTouchingGrabWall = player.CheckIfWall();

    }

    public override void Enter()
    {
        base.Enter();       

        detectPointHit = player.WallSensor.pointHit;

        defaultContactOffset = Physics2D.defaultContactOffset;

        posX = detectPointHit.x - (player.BodyCollider.size.x / 2 + defaultContactOffset) * player.FacingDirection;
        posY = detectPointHit.y - player.WallSensor.startHitUp;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetAnimation();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SetAnimation()
    {

        player.Animator.SetInteger("amountJump", player.JumpState.AmountOfJumpsLeft);
    }


    protected void HoldPosition()
    {
        holdPosition = new Vector2(posX, posY); 
        player.transform.position = holdPosition;
    }



}
