﻿using UnityEngine;
using System.Collections;

/*
 * this class represents the crouch variation of the heavy attack.
 * this state is entered when the heavy attack button is pressed while in the crouch state.
 * from this state you can enter the crouch, idle, and hitstun states.
 */

public class CrouchHeavyAttackState : State1 {

	[SerializeField] private StateMachine1 stateMachine;
	[SerializeField] private Animator anim;
	[SerializeField] private float lockTime;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip sweepSound;
	public override void Enter()
	{
		anim.SetInteger("AnimState", 10);
		audioSource.PlayOneShot (sweepSound);
	}

	public override void Act()
	{

	}

	public override void Reason()
	{
		if(!Input.GetKeyDown(KeyCode.Z))
		{
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch kick"))
			{
				StartCoroutine(LightAtkLockTime());
			}
		}
	}

	public override void Leave()
	{

	}

	IEnumerator LightAtkLockTime()
	{
		yield return new WaitForSeconds(lockTime);
		if(!Input.anyKey)
			stateMachine.SetState(StateID.Idle);
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			stateMachine.SetState(StateID.Crouch);
		}
	}
}
