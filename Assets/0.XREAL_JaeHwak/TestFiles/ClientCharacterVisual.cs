using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// static import
using MovementState = ClientCharacterMovement.MovementState;

public class ClientCharacterVisual : MonoBehaviour
{
    [SerializeField]//set in inspector!
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }
/*    public void OnMovementStateEntered(MovementState state)
    {
        //Let's debug if this function is properly called on state changes.
        if (!_anim) return;
        Debug.Log("in state " + state);
    }*/

    public void OnMovementStateEntered(MovementState state)
    {
        switch (state)
        {
            case MovementState.Idle:
                _anim.SetBool("bWalk", false);
                break;

            case MovementState.Walking:
                _anim.SetBool("bWalk", true);
                break;

            case MovementState.Jump:
                _anim.SetTrigger("tJump");
                break;

            case MovementState.Landing:
                _anim.SetTrigger("tLand");
                break;
        }
    }
}
