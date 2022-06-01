using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandingOnWallState : PlayerOnWallState
{
    public PlayerLandingOnWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }

    private Vector2 currentPos;
    private Vector2 lastPos;


    public override void DoChecks()
    {
        base.DoChecks();

    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();





        if (isAnimationFinished)
        {
            lastPos.x = player.transform.position.x;
            stateMachine.ChangeState(player.IdleOnWallState);
        }




    }


    private bool CheckEqualityXposition()
    {

        if (currentPos.x.Equals(lastPos.x))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
