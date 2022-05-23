using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    //Input
    protected float xInputForce;
    protected int xInput;
    protected int yInput;
    protected bool jumpInput;
    protected bool dashImput;

    //Check
    protected bool isSlope;
    protected bool isRoof;
    private bool isGrounded;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
    }
    
    public override void Enter()
    {
        base.Enter();        
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
        isRoof = player.CheckIfRoof();
        isSlope = player.CheckIfSlope();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        SetAnimation();

        xInputForce = player.InputController.InputForceX;
        xInput = player.InputController.NormInputX;
        jumpInput = player.InputController.JumpInput;
        dashImput = player.InputController.DashInput;


        //Debug.Log(player.InputController.InputForceX);



        if (!isGrounded)
        {
            stateMachine.ChangeState(player.FallState);
        }
    }

    private void SetAnimation()
    {
        player.Animator.SetBool("wasCrouch", player.wasCrouch);
    }
}
