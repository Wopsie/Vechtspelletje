﻿using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking forward.
 * this state is entered when the analogue stick is tilted towards the opponent in either the idle or walking backwards state.
 */

public class WalkForwardState : State1 {

    [SerializeField] private StateMachine1 stateMachine;
    [SerializeField] private Animator anim;
    [SerializeField] private Vector3 moveVector;
	[SerializeField] private StateFreeInputHandler inputHandler;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip walkingSound;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 2);
    }

    public override void Act()
    {
        transform.Translate(moveVector * Time.deltaTime);
		audioSource.PlayOneShot(walkingSound);
    }

    public override void Reason()
    {
        anim.SetInteger("AnimState", 2);
		if (inputHandler.returnHadouken ()) 
		{
			stateMachine.SetState (StateID.LightSpecial);
		}
        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID.Idle);
        }
        else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            stateMachine.SetState(StateID.WalkBackward);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            stateMachine.SetState(StateID.StandLightAttack);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.SetState(StateID.StandHeavyAttack);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(StateID.JumpForward);
        }
    }

    public override void Leave()
    {
    }
}
