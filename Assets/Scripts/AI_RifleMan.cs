﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_RifleMan : MonoBehaviour
{

    NavMeshAgent agent;
    Animator anim;
    Transform target;
    [SerializeField] float range;
    StateParam _stateParam; 
    State currentState;

    public enum TEAM
    { TEAM_RED, TEAM_BLUE }
    [SerializeField] TEAM team;
    [SerializeField] ParticleSystem fireVFX;

    void Start()
    {
        _stateParam = new StateParam();
        _stateParam.unit = gameObject;
        _stateParam.agent = this.GetComponent<NavMeshAgent>();
        _stateParam.anim = this.GetComponent<Animator>();
        _stateParam.range = range;
        _stateParam.target = null;


        currentState = new State_Advance(_stateParam);
    }

    void Update()
    {
        currentState = currentState.Process();
    }

    public void FireVFX()
    {
        fireVFX.Play();
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}