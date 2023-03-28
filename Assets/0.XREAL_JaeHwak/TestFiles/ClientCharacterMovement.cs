using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClientCharacterMovement : MonoBehaviour
{
    private InputAction _movePosition;
    private InputAction _moveAction;
    private InputAction _jumpAction;

    private bool _move = false;
    private Vector3 _targetPos;
    private float _distanceCheck = 0.1f;

    [SerializeField]
    private float _walkSpeed = 1.0f;
    private Animator _anim;
    private CharacterController _controller;

    public event Action<MovementState> OnStateEntered = null;

    void Start()
    {
        ClientCharacterVisual visual = GetComponentInChildren<ClientCharacterVisual>();
        if (visual) OnStateEntered += visual.OnMovementStateEntered;

        var playerInput = GetComponent<PlayerInput>();
        _movePosition = playerInput.actions["LocoTarget"];
        _moveAction = playerInput.actions["MoveTarget"];
        _jumpAction = playerInput.actions["Jump"];
        _targetPos = transform.position;
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();

        _currentState = MovementState.Idle;
        StateEntered(_currentState);
    }

    bool _makeTransition = false;
    private void Update()
    {


        if (_makeTransition)
        {
            StateExit(_currentState);
            _currentState = _nextState;
            StateEntered(_currentState);
        }

        // state machine update
        switch (_currentState)
        {

            case MovementState.InAir:
            case MovementState.Jump:
                _verticalVelocity += _gravity * Time.deltaTime;
                break;
            case MovementState.Idle:
            case MovementState.Walking:
                if (_verticalVelocity < 0.0f) _verticalVelocity = -0.0f;
                break;
        }

        //this happens regardless of state
        CalculateHorizontalVelocity(_targetPos);
        _controller.Move(_horizontalVelocity * Time.deltaTime
    + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        // calculate what comes next
        _makeTransition = Transition(out _nextState);

    }
    public enum MovementState : uint
    {
        Idle,
        Walking,
        InAir,
        Jump,
        Landing
    }
    MovementState _currentState = MovementState.Idle;
    MovementState _nextState = MovementState.Idle;
    private void StateExit(MovementState fromState)
    {

    }

    private void StateEntered(MovementState toState)
    {
        if (toState == MovementState.Jump)
        {
            _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
        OnStateEntered(toState);
        /*        switch (toState)
                {
                    case MovementState.Idle:
                        _anim.SetBool("bWalk", false);
                        break;

                    case MovementState.Walking:
                        _anim.SetBool("bWalk", true);
                        break;

                    case MovementState.Jump:
                        _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
                        _anim.SetTrigger("tJump");
                        break;

                    case MovementState.Landing:
                        _anim.SetTrigger("tLand");
                        break;
                }*/
    }

    private bool Transition(out MovementState nextState)
    {
        nextState = _currentState;
        switch (_currentState)
        {
            case MovementState.Idle:
                if (_jumpAction.triggered) nextState = MovementState.Jump;
                else if (_moveAction.triggered && SetMovementTarget()) nextState = MovementState.Walking;
                break;
            case MovementState.Walking:
                if (_horizontalVelocity == Vector3.zero) nextState = MovementState.Idle;
                else if (_jumpAction.triggered) nextState = MovementState.Jump;
                else if (_moveAction.triggered && SetMovementTarget()) nextState = MovementState.Walking;
                break;
            case MovementState.Jump:
                if (!GroundCheck() && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
                    nextState = MovementState.InAir;
                    //nextState = _horizontalVelocity.magnitude > 0.0f ? MovementState.Walking : MovementState.Idle;
                break;
            case MovementState.InAir:
                if (GroundCheck()) nextState = MovementState.Landing;
                break;
            case MovementState.Landing:
                if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
                {
                    nextState = _horizontalVelocity.magnitude > 0.0f ? MovementState.Walking : MovementState.Idle;
                }
                break;
        }
        if (nextState != _currentState) return true;
        return false;
    }

    private bool SetMovementTarget()
    {
        // mouse position
        Vector2 screenPos = _movePosition.ReadValue<Vector2>();
        var ray = Camera.main.ScreenPointToRay(screenPos);
        if (!Physics.Raycast(ray, out RaycastHit hit, 500.0f, LayerMask.GetMask("Ground"))) return false;

        // calculate the distance to the hit point
        Vector3 groundTargetPos = new Vector3(hit.point.x, 0.0f, hit.point.z);
        Vector3 groundPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        if (Vector3.Magnitude(groundPos - groundTargetPos) < _distanceCheck)
        {
            _targetPos = transform.position;
            return false;
        }
        else
        {
            _targetPos = hit.point;
            return true;
        }
    }



    [SerializeField]
    private float _gravity = -9.8f;
    [SerializeField]
    private float _jumpHeight = 1.0f;
    [SerializeField]
    private Transform _footTransform;
    private float _groundedRadius = 0.3f;

    private float _verticalVelocity = 0.0f;
    private Vector3 _horizontalVelocity = Vector3.zero;

    private bool GroundCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = _footTransform.position;
        bool check = Physics.CheckSphere(spherePosition, _groundedRadius, LayerMask.GetMask("Ground"), QueryTriggerInteraction.Ignore);
        return check;
    }


    private void OnDrawGizmos()
    {
        if (GroundCheck()) Gizmos.color = Color.green;
        else Gizmos.color = Color.red;
        Vector3 spherePosition = _footTransform.position;
        Gizmos.DrawSphere(spherePosition, _groundedRadius);
    }

    private bool CalculateHorizontalVelocity(Vector3 _targetPos)
    {
        Vector3 groundTargetPos = new Vector3(_targetPos.x, 0.0f, _targetPos.z);
        Vector3 groundPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        if (Vector3.Magnitude(groundPos - groundTargetPos) < _distanceCheck)
        {
            // arrived. cancel move.
            _horizontalVelocity = Vector3.zero;
            return false;
        }
        // should move towards target
        //transform.position = Vector3.MoveTowards(transform.position, _targetPos, Time.deltaTime * _walkSpeed);
        _horizontalVelocity = (groundTargetPos - groundPos).normalized * _walkSpeed;
        transform.LookAt(transform.position + _horizontalVelocity, Vector3.up);
        return true;
    }
}