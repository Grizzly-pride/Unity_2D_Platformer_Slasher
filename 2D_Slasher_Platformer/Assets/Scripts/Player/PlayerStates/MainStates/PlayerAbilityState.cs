using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    private bool isGrounded;
    protected bool isRoof;
    protected bool isAbilityDone;
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
        isRoof = player.CheckIfRoof();  
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAbilityDone)
        {
            if (isGrounded && player.currentMotion.y < 0.01f)
            {
                if (isRoof || player.wasCrouch)
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
                stateMachine.ChangeState(player.FallState);
            }
        }        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
