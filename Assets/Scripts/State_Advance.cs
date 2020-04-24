using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Advance : State
{
    public State_Advance(StateParam param) : base(param)
    {
        name = STATE.Advance;
    }

    public override void Enter()
    {
        _stateParam.agent.destination = _stateParam.destination.position;
        base.Enter();
    }

    public override void Update()
    {
        string[] param = {"Unit", "Building"};
        
        LayerMask mask = LayerMask.GetMask(param);


        // RaycastHit[] hits = Physics.SphereCastAll(_stateParam.unit.transform.position, 
        //     _stateParam.range, _stateParam.unit.transform.forward, 
        //     Mathf.Epsilon, mask);

        Collider[] cols = Physics.OverlapSphere(_stateParam.unit.transform.position, 
            _stateParam.range, mask);        


        //Check if there is self in it and exclude self
        List<Collider> colsList = new List<Collider>();
        foreach(Collider col in cols)
        {
            if(col.transform != _stateParam.unit.transform)
            {
                colsList.Add(col);
            } 
        }



        // if( there is enemy in range ) then go to shoot state
        if(colsList.Count > 0)
        {
            _stateParam.target = colsList[0].transform;

            foreach(Collider col in colsList)
            {
                Debug.Log(col.transform.name);
            }
            Debug.Log("Something in Range(Unit or Building)");


            nextState = new State_Shoot(_stateParam);
            stage = EVENT.EXIT;
        }
        


        // else keep advance ; base.Update() ;
    }

    public override void Exit()
    {
        //_stateParam.agent.destination = _stateParam.unit.transform.position;
        base.Exit();
    }
}
