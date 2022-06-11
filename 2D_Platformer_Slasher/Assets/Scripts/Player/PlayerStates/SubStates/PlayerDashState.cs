using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    protected float lastDashTime;
    protected bool applyMotion;
    public override void DoChecks()
    {
        base.DoChecks();
        player.InputController.UseDashInput();
        HoldOnSlope();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetColliderHeight(data.crouchColiderHeight);
        player.InputController.UseDashInput();
        startTime = Time.time;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
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
