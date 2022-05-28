using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

    private PlayerInput playerInput;
    public Vector2 MoveInput { get; private set; }
    public float InputForceX { get; private set; }
    public float InputForceY { get; private set; }
    public int NormInputX { get; private set;}
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool SitDownInput { get; private set; }  
    public bool StandUpInput { get; private set; }


    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {

        ResetJumpInput();
        ResetDashInput();
        ResetSitDownInput();
        ResetStandUpInput();

    }


    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();

        InputForceX = Mathf.Abs(MoveInput.x);
        InputForceY = Mathf.Abs(MoveInput.y);

        if (InputForceX > 0.5f)
        {
            NormInputX = (int)(MoveInput * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }

        if (InputForceY > 0.5f)
        {
            NormInputY = (int)(MoveInput * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
    
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
        }
        if (context.canceled)
        {
            JumpInput = false;
        }

    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
        }
        if (context.canceled)
        {
            DashInput = false;
        }
    }


    public void OnSitDownInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SitDownInput = true;
        }
        if (context.canceled)
        {
            SitDownInput = false;
        }

    }

    public void OnStandUpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StandUpInput = true;
        }
        if (context.canceled)
        {
            StandUpInput = false;
        }

    }



    //Тригеры отмены нажатия
    public void UseJumpInput() => JumpInput = false;
    public void UseDashInput() => DashInput = false;

    public void UseSitDownInput() => SitDownInput = false;
    public void UseStandUpInput() => StandUpInput = false;



    //Сброс сумирования нажатия

   
    private void ResetJumpInput()
    {
        if (JumpInput)
        {
            JumpInput = false;
        }
    }
    

    private void ResetDashInput()
    {
        if (DashInput)
        {
            DashInput = false;
        }
    }

    
    private void ResetSitDownInput()
    {
        if (SitDownInput)
        {
            SitDownInput = false;
        }
    }

    private void ResetStandUpInput()
    {
        if (StandUpInput)
        {
            StandUpInput = false;
        }
    }
    




}
 