using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData data;

    protected float startTime;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    private readonly string animName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName)
    {
        this.player = player;   
        this.stateMachine = stateMachine;
        this.data = data;
        this.animName = animName;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Animator.SetBool(animName, true);
        startTime = Time.time;

        Debug.Log(animName);

        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        player.Animator.SetBool(animName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {
        DoChecks();
    }


 
    public virtual void PhysicsUpdate()
    {
        //DoChecks();
    }

    public virtual void DoChecks() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

}

