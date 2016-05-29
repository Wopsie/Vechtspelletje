﻿using UnityEngine;
using System.Collections;

/*
 * this class represents the standing light attack state.
 * this state is entered when the character is in his idle state and the light attack button is pressed.
 */

public class StandLightAttackState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float lockTime;

    [SerializeField]
    private GameObject hitBox;


    public override void Enter()
    {
        anim.SetInteger("AnimState", 3);
    }

    public override void Act()
    {
        anim.SetInteger("AnimState", 3);
    }

    public override void Reason()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("L punch"))
        {
            StartCoroutine(LightAtkLockTime());
        }
    }

    public override void Leave()
    {
        
    }

    void ActivateLightHitbox()
    {
        //this method is called via animation event
        hitBox.SetActive(true);
    }

    void DeactivateLightHitbox()
    {
        //this method is called via animation event
        hitBox.SetActive(false);
    }

    //time untill player can move again
    IEnumerator LightAtkLockTime()
    {
        yield return new WaitForSeconds(lockTime);
        stateMachine.SetState(StateID.Idle);
    }
}
