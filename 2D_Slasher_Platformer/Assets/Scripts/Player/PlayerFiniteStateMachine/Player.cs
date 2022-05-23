using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables 
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerStandIdleState StandIdleState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerWalckState WalckState { get; private set;}
    public PlayerRunStopState RunStopState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerDoubleJumpState DoubleJumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerHardLanding HardLanding { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerSitDownState SitDownState { get; private set; }
    public PlayerStandUpState StandUpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerDashToStandState DashToStandState { get; private set; }
    public PlayerDashToCrouchState DashToCrouchState { get; private set; }
    #endregion

    #region Components
    public Animator Animator { get; private set; }
    public PlayerInputController InputController { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D BodyCollider { get; private set; }
    public SensorSurface GroundSensor { get; private set; }
    public SensorCollision RoofSensor { get; private set; }
    public SensorCollision WallSensor { get; private set; } 
    #endregion

    #region Variables
    [SerializeField] private PlayerData data;

    public Vector2 currentMotion;
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
        JumpState = new PlayerJumpState(this, StateMachine, data, "jump");
        DoubleJumpState = new PlayerDoubleJumpState(this, StateMachine, data, "doubleJump");
        FallState = new PlayerFallState(this, StateMachine, data, "fall");
        LandState = new PlayerLandState(this, StateMachine, data, "land");
        HardLanding = new PlayerHardLanding(this, StateMachine, data, "hardLanding");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, data, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, data, "crouchMove");
        SitDownState = new PlayerSitDownState(this, StateMachine, data, "sitDown");
        StandUpState = new PlayerStandUpState(this, StateMachine, data, "standUp");
        DashToStandState = new PlayerDashToStandState(this, StateMachine, data, "dashToStand");
        DashToCrouchState = new PlayerDashToCrouchState(this, StateMachine, data, "dashToCrouch");
        DashState = new PlayerDashState(this, StateMachine, data, "dash");

        //Sensors
        GroundSensor = transform.Find("GroundCheck").GetComponent<SensorSurface>();
        RoofSensor = transform.Find("RoofCheck").GetComponent<SensorCollision>();
        WallSensor = transform.Find("WallCheck").GetComponent<SensorCollision>();

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
        RoofSensor.detected = false;
        WallSensor.detected = false;    
        FacingDirection = 1;

        //Initialization State
        StateMachine.Initialize(StandIdleState);
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();

    }

    private void Update()
    {
        currentMotion = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();

        CheckIfWall();


    }
    #endregion

    #region Set Functions   

    public void MovementOnGround(bool slope, float velocity, int xDirect)
    {
        if (slope)
        {
            SetVelocitySlope(velocity, xDirect);
            
        }
        else 
        {
            SetVelocitySmooth(velocity, xDirect);
        }

    }

    public void SetVelocitySlope(float velocity, int xDirect)
    {
        vectorWorkSpace.Set(-xDirect * velocity * GroundSensor.slopeDirection.x, -xDirect * velocity * GroundSensor.slopeDirection.y);
        SetFinalVelocity();
    }

    public void SetVelocitySmooth(float velocity, int xDirect)
    {
        vectorWorkSpace.Set(velocity * xDirect, Vector2.zero.x);
        SetFinalVelocity();
    }

    public void SetVelocityX(float velocity)
    {
        vectorWorkSpace.Set(velocity, currentMotion.y);
        SetFinalVelocity();
    }

    public void SetVelocityY(float velocity)
    {
        vectorWorkSpace.Set(currentMotion.x, velocity);
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
        currentMotion = vectorWorkSpace;
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

    public void SetFlip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion

    #region Check Functions
    public bool CheckIfGrounded()
    {
        GroundSensor.CheckSurface();
        return GroundSensor.detected;
    }

    public bool CheckIfRoof()
    {
        RoofSensor.CheckCollision();
        return RoofSensor.detected;
    }

    public bool CheckIfWall()
    {
        WallSensor.CheckCollision(FacingDirection);
        return WallSensor.detected;
    }

    
    public bool CheckIfSlope()
    {
        GroundSensor.CheckSurface();
        return GroundSensor.isOnSlope;
    }


    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
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
