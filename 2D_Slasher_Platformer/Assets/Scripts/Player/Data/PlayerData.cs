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
    public float jumpForce = 11f;
    public float doubleJumpForce = 9f;
    public float airMoveX = 5f;

    [Header("LANDING STATE")]
    public float thresholdHardLanding = -15.0f;

    [Header("DASH STATE")]
    public float dashSpeed = 9f;
    public float dashCoolDown = 0.5f;
    public float dashTime = 0.3f;   

}
