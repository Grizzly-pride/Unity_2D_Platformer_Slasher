using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWallState : PlayerState
{
    public PlayerOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    private Vector2 holdPosition;
    private Vector2 detectPointHit;
    private float posX;
    private float posY;
    private float defaultContactOffset;


    public override void Enter()
    {
        base.Enter();

        player.WallJumpState.DetermineWallJumpDerection(player.CheckIfWall());

        player.SetVelocityZero();

        detectPointHit = player.GetWallDetectPoint();
        defaultContactOffset = Physics2D.defaultContactOffset;
        posX = detectPointHit.x - (player.BodyCollider.size.x / 2 + defaultContactOffset) * player.FacingDirection;
        posY = detectPointHit.y - player.WallSensor.startHitUp;

    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetAnimation();
    }



    private void SetAnimation()
    {
        player.Animator.SetInteger("amountJump", player.JumpState.AmountOfJumpsLeft);
    }

    protected void HoldPosition()
    {
        holdPosition.Set(posX, posY);
        player.transform.position = holdPosition;
    }

}
