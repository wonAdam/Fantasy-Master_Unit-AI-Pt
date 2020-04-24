using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Shoot : State
{
    public State_Shoot(StateParam param) : base(param)
    {
        name = STATE.Shoot;
    }

    public override void Enter()
    {
        _stateParam.anim.SetBool("isShooting", true);
        base.Enter();
    }

    public override void Update()
    {
        // if( enemy in range ) then keep shooting
        if(Vector3.Distance(_stateParam.target.position, _stateParam.unit.transform.position) 
            <= _stateParam.range)
        {
            _stateParam.unit.transform.LookAt(_stateParam.target);
            _stateParam.agent.destination = _stateParam.unit.transform.position;
            

            //some damage system implementation
            //... or in animation event


        }
        // else go to advance state
        else
        {
            _stateParam.target = null;
            nextState = new State_Advance(_stateParam);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        _stateParam.anim.SetBool("isShooting", false);
        base.Exit();
    }
}
