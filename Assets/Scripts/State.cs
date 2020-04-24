using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateParam
{
    public GameObject unit;
    public NavMeshAgent agent;
    public Animator anim;
    public Transform destination;
    public float range;
    public Transform target;

}

public class State
{
    // if you change this var, you can go to the state
    public STATE name;


    protected State nextState;
    protected EVENT stage;
    protected StateParam _stateParam;
    public enum EVENT
    { ENTER, UPDATE, EXIT } 

    public enum STATE
    { Advance, Shoot }
    

    public State(StateParam param)
    {
        _stateParam = param;
        stage = EVENT.ENTER;
        // Debug.Log(_stateParam);
        // Debug.Log(_stateParam.agent);
        // Debug.Log(_stateParam.anim);
        // Debug.Log(_stateParam.range);
        // Debug.Log(_stateParam.target);
    }


    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
    {

        if(stage == EVENT.ENTER) Enter();
        if(stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }

        return this;
    }



}
