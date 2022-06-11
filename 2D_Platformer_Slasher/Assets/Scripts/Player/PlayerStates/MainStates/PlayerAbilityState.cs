using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    protected bool isAbilityDone;
    protected bool isGrounded;
    protected bool isRoof;
    protected bool isSlope;

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded  = player.CheckIfGrounded();
        isRoof = player.CheckIfRoof();
        isSlope = player.CheckIfSlope();
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;
    }



    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAbilityDone)
        {
            if (isGrounded && player.CurrentMotion.y < 0.01f)
            {
                if(isRoof || player.wasCrouch)
                {
                    stateMachine.ChangeState(player.CrouchIdleState);
                }
                else
                {
                    stateMachine.ChangeState(player.StandIdleState);
                    
                }
            }
            else
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


}
