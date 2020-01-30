﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("The speed in which the player moves")]
    public float runSpeed = 40f;

    private float _horizontalMove = 0f;
    private bool _jump = false;
    private bool _crouch = false;

    /// <summary>
    /// Reference to the CharacterController2D script
    /// </summary>
    private CharacterController2D _controller;

    /// <summary>
    /// Reference to the InputMaster script created by the InputSystemAsset
    /// </summary>
    private InputMaster _controls;

    /// <summary>
    /// Reference to the Animator script created by the InputSystemAsset
    /// </summary>
    private Animator _animator;

    #region(UnityFunctions)
    private void OnValidate()
    {
        runSpeed = Mathf.Clamp(runSpeed, 0, float.MaxValue);
    }

    void Awake()
    {
        _controls = new InputMaster();
        _controller = gameObject.GetComponent(typeof(CharacterController2D)) as CharacterController2D;
        _animator = gameObject.GetComponent(typeof(Animator)) as Animator;


        _controls.Player.Movement.performed += context => Move(context.ReadValue<float>());
        _controls.Player.Jump.performed += context => Jump();
        _controls.Player.Crouch.performed += context => Crouch();
    }

    void FixedUpdate()
    {
        // Moves the character based on given variables * fixedDeltaTime
        _controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);
        _jump = false;
    }


    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
    #endregion

    #region(OwnFunctions)
    void Move(float direction)
    {
        _horizontalMove = direction * runSpeed;

        //Using the absolute so given value is never negative
        _animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));
    }

    void Jump()
    {
        _jump = true;
        _animator.SetBool("IsJumping", true);
    }

    void Crouch()
    {
        if (_crouch)
        {
            //Stand up
            _crouch = false;
        }
        else
        {
            //Crouch
            _crouch = true;
        }
    }

    public void OnLanding()
    {
        _animator.SetBool("IsJumping", false);
    }


    public void OnCrouching(bool isCrouching)
    {
        _animator.SetBool("IsCrouching", isCrouching);
    }
    #endregion
}
