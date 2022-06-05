using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public int AmountOfJumpsLeft { get; private set; }
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animName) : base(player, stateMachine, data, animName)
    {
        AmountOfJumpsLeft = data.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        player.InputController.UseJumpInput();
        player.SetVelocityY(data.jumpForce);
        isAbilityDone = true;
    }


    public bool CanJump()
    {
        if (AmountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAmountOfJumpsLeft() => AmountOfJumpsLeft = data.amountOfJumps;
    public void DecreaseAmountOfJumpsLeft() => AmountOfJumpsLeft--;

}
