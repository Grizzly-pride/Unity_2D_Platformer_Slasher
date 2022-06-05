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

    private float Xpos;
    private float Ypos;
    private float defaultContactOffset;


    public override void DoChecks()
    {
        base.DoChecks();
        isTouchingGrabWall = player.CheckIfWall();

    }

    public override void Enter()
    {
        base.Enter();
        detectPointHit = player.WallSensor.pointHit1;

        defaultContactOffset = Physics2D.defaultContactOffset;

        Xpos = detectPointHit.x - (player.BodyCollider.size.x / 2 + defaultContactOffset) * player.FacingDirection;
        Ypos = detectPointHit.y - player.WallSensor.hitPosition1.y;

        HoldPosition();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HoldPosition();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void HoldPosition()
    {
        holdPosition = new Vector2(Xpos, Ypos); 
        player.transform.position = holdPosition;
    }



}
