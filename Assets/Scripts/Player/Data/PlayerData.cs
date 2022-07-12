using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("PHYSICS MATERIAL")]
    public PhysicsMaterial2D noFrictionMaterial;
    public PhysicsMaterial2D frictionMaterial;

    [Header("STAND STATE")]
    public float runSpeed = 5f;
    public float walckSpeed = 3f;
    public float runningThreshold = 0.8f;
    public float standColiderHeight = 1.38f;

    [Header("CROUCH STATE")]
    public float crouchSpeed = 2f;
    public float crouchColiderHeight = 0.84f;

    [Header("JUMP STATE")]
    public int amountOfJumps = 1;
    public float jumpForce = 11f;
    public float airMoveX = 5f;

    [Header("JUMP WALL STATE")]
    public float wallJumpTime = 0.4f;
    public float wallJumpForce = 20f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("LANDING STATE")]
    public float thresholdHardLanding = -15.0f;

    [Header("DASH STAND STATE")]
    public float dashStandSpeed = 9f;
    public float dashStandCoolDown = 0.5f;
    public float dashStandTime = 0.3f;

    [Header("DASH CROUCH STATE")]
    public float dashCrouchSpeed = 9f;
    public float dashCrouchCoolDown = 0.5f;
    public float dashCrouchTime = 0.3f;

}
