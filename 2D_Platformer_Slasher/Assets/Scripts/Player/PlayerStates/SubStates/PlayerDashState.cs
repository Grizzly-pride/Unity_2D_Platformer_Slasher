using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    protected bool isSlope;
    protected float lastDashTime;
    public override void DoChecks()
    {
        base.DoChecks();
        isSlope = player.CheckIfSlope();
        player.InputController.UseDashInput();
        player.SetColliderHeight(data.crouchColiderHeight);     
    }

    public override void Enter()
    {
        base.Enter();
        player.InputController.UseDashInput();
        startTime = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HoldOnSlope();

    }

    public bool CheckIfCanDash()
    {
        return Time.time >= lastDashTime + data.dashStandCoolDown;
    }

    private void HoldOnSlope()
    {
        if (isSlope && player.RB.gravityScale.Equals(1))
        {
            player.SetGravityOff();
        }
        else if (!isSlope && player.RB.gravityScale.Equals(0))
        {
            player.SetGravityOn();
        }
    }
}
