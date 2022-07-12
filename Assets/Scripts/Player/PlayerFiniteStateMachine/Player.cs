using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    #region State Variables 
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerStandIdleState StandIdleState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerWalckState WalckState { get; private set;}
    public PlayerRunStopState RunStopState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerHardLanding HardLanding { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerSitDownState SitDownState { get; private set; }
    public PlayerStandUpState StandUpState { get; private set; }
    public PlayerDashState DashState { get; private set; }  
    public PlayerDashStandState DashStandState { get; private set; }
    public PlayerDashToStandState DashToStandState { get; private set; }
    public PlayerDashCrouchState DashCrouchState { get; private set; }
    public PlayerDashToCrouchState DashToCrouchState { get; private set; }
    public PlayerIdleOnWallState IdleOnWallState { get; private set; }  
    public PlayerLandingOnWallState LandingOnWallState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerOnWallState OnWallState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; } 
    public PlayerOnLedgeState OnLedgeState { get; private set; }
    #endregion

    #region Components
    public Animator Animator { get; private set; }
    public PlayerInputController InputController { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D BodyCollider { get; private set; }
    public AnimationEvent AnimationEvent { get; private set; }
    public SensorGround GroundSensor { get; private set; }
    public SensorRoof RoofSensor { get; private set; }
    public SensorWall WallSensor { get; private set; } 
    public SensorLedge LedgeSensor { get; set; }
    #endregion


    #region Variables
    [SerializeField] private PlayerData data;

    public Vector2 CurrentMotion { get; private set; }
    public Vector2 vectorWorkSpace;

    public int FacingDirection { get; private set; }
    public bool wasCrouch;
    #endregion

    #region Unity Functions
    private void Awake()
    {        
        StateMachine = new PlayerStateMachine();

        //Behavior States
        StandIdleState = new PlayerStandIdleState(this, StateMachine, data, "standIdle");
        WalckState = new PlayerWalckState(this, StateMachine, data, "walck");
        RunState = new PlayerRunState(this, StateMachine, data, "run");
        RunStopState = new PlayerRunStopState(this, StateMachine, data, "runStop");

        LandState = new PlayerLandState(this, StateMachine, data, "land");
        HardLanding = new PlayerHardLanding(this, StateMachine, data, "hardLanding");

        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, data, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, data, "crouchMove");

        SitDownState = new PlayerSitDownState(this, StateMachine, data, "sitDown");
        StandUpState = new PlayerStandUpState(this, StateMachine, data, "standUp");

        DashStandState = new PlayerDashStandState(this, StateMachine, data, "dashStand");
        DashToStandState = new PlayerDashToStandState(this, StateMachine, data, "dashToStand");

        DashCrouchState = new PlayerDashCrouchState(this, StateMachine, data, "dashCrouch");
        DashToCrouchState = new PlayerDashToCrouchState(this, StateMachine, data, "dashToCrouch");

        IdleOnWallState = new PlayerIdleOnWallState(this, StateMachine, data, "idleOnWall");
        LandingOnWallState = new PlayerLandingOnWallState(this, StateMachine, data, "landingOnWall");

        InAirState = new PlayerInAirState(this, StateMachine, data, "inAirState");
        JumpState = new PlayerJumpState(this, StateMachine, data, "inAirState");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, data, "inAirState");

        OnLedgeState = new PlayerOnLedgeState(this, StateMachine, data, "onLedgeState");

        //Sensors
        GroundSensor = transform.Find("GroundCheck").GetComponent<SensorGround>();
        RoofSensor = transform.Find("RoofCheck").GetComponent<SensorRoof>();
        WallSensor = transform.Find("WallCheck").GetComponent<SensorWall>();
        LedgeSensor = transform.Find("LedgeCheck").GetComponent<SensorLedge>();

        //Components
        Animator = GetComponent<Animator>();
        InputController = GetComponent<PlayerInputController>();
        RB = GetComponent<Rigidbody2D>();
        BodyCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        GroundSensor.detected = false;
        GroundSensor.isOnSlope = false;
        FacingDirection = 1;
        wasCrouch = false;

        //Initialization State
        StateMachine.Initialize(StandIdleState);
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void Update()
    { 
        CurrentMotion = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();            
    }


    #endregion

    #region Set Functions   

    public void MovementOnGround(bool slope, float velocity, int xDirect)
    {
        if (slope)
        {
            MovementOnSlope(velocity, xDirect);
            
        }
        else 
        {
            MovementOnSmooth(velocity, xDirect);
        }
    }

    public void MovementOnSlope(float velocity, int xDirect)
    {
        vectorWorkSpace.Set(-xDirect * velocity * GroundSensor.slopeDirection.x, -xDirect * velocity * GroundSensor.slopeDirection.y);
        SetFinalVelocity();
    }

    public void MovementOnSmooth(float velocity, int xDirect)
    {
        vectorWorkSpace.Set(velocity * xDirect, Vector2.zero.x);
        SetFinalVelocity();
    }
    
    public void SetVelocity(float velocity, Vector2 angle, int xDirect)
    {
        angle.Normalize();
        vectorWorkSpace.Set(angle.x * velocity * xDirect, angle.y * velocity);
        SetFinalVelocity();
    }

    public void SetVelocityX(float velocity)
    {
        vectorWorkSpace.Set(velocity, CurrentMotion.y);
        SetFinalVelocity();
    }

    public void SetVelocityY(float velocity)
    {
        vectorWorkSpace.Set(CurrentMotion.x, velocity);
        SetFinalVelocity();
    }

    public void SetVelocityZero()
    {
        vectorWorkSpace = Vector2.zero;
        SetFinalVelocity();
    }

    public void SetFinalVelocity()
    {
        RB.velocity = vectorWorkSpace;
        CurrentMotion = vectorWorkSpace;
    }


    public void SetColliderHeight(float height)
    {
        Vector2 center = BodyCollider.offset;
        vectorWorkSpace.Set(BodyCollider.size.x, height);

        center.y += (height - BodyCollider.size.y) / 2;

        BodyCollider.size = vectorWorkSpace;
        BodyCollider.offset = center;
    }

    public void SetPhysicsMaterial(PhysicsMaterial2D material)
    {
        RB.sharedMaterial = material;
    }

    public void SetGravityOff()
    {
        RB.gravityScale = 0.0f;
    }
    public void SetGravityOn()
    {
        RB.gravityScale = 1.0f;
    }

    public void SetFlip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion

    #region Check Functions
    public bool CheckIfGrounded()
    {
        GroundSensor.Checking();
        return GroundSensor.detected;
    }

    public bool CheckIfRoof()
    {
        RoofSensor.Checking();
        return RoofSensor.detected;
    }

    public bool CheckIfWall()
    {
        WallSensor.Checking(FacingDirection);
        return WallSensor.detected;
    }

    public Vector2 GetWallDetectPoint()
    {
        return WallSensor.pointHit;
    }

    public bool CheckIfLedge()
    {
        LedgeSensor.Checking(FacingDirection);
        return LedgeSensor.detected;
    }

    public Vector2 GetLedgePointAngle()
    {
        return LedgeSensor.pointAngle;
    }


    public bool CheckIfSlope()
    {
        GroundSensor.Checking();
        return GroundSensor.isOnSlope;
    }


    public void CheckIfShouldFlip(int xDirect)
    {
        if (xDirect != 0 && xDirect != FacingDirection)
        {
            SetFlip();
        }
    }

    #endregion

    #region Trigers Functions
    private void AnimationTriger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    #endregion


}
