﻿using UnityEngine;
using System.Collections;

/*
 * this class represents the default state of the character.
 * if the character is given no inputs and is not hit by anything it will assume this state.
 */

public class IdleState1 : State1 {

    [SerializeField] private StateMachine1 stateMachine;
    [SerializeField] private Animator anim;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 0);
        Debug.Log("Idle Enter");
    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //walk left
            stateMachine.SetState(StateID.WalkBackward);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //walk right
            stateMachine.SetState(StateID.WalkForward);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            stateMachine.SetState(StateID.StandLightAttack);
        }
        if (Input.GetKey(KeyCode.X))
        {
            stateMachine.SetState(StateID.StandHeavyAttack);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            stateMachine.SetState(StateID.Jump);
        }
    }

    public override void Leave()
    {
        
    }
}
