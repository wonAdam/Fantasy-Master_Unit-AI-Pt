using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_RifleMan : MonoBehaviour
{

    NavMeshAgent agent;
    Animator anim;
    Transform target;
    Transform dest;
    [SerializeField] float range;
    StateParam _stateParam; 
    State currentState;

    public enum TEAM
    { TEAM_RED, TEAM_BLUE }
    [SerializeField] TEAM team;
    [SerializeField] ParticleSystem fireVFX;

    void Start()
    {
        Base[] bases = FindObjectsOfType<Base>();
        foreach(Base _base in bases)
        {
            if(_base.tag == "RED_BASE" && team == TEAM.TEAM_BLUE) 
                { dest = _base.transform; break; }
            else if(_base.tag == "BLUE_BASE" && team == TEAM.TEAM_RED) 
                { dest = _base.transform; break; }
        }

        _stateParam = new StateParam();
        _stateParam.unit = gameObject;
        _stateParam.agent = this.GetComponent<NavMeshAgent>();
        _stateParam.anim = this.GetComponent<Animator>();
        _stateParam.destination = dest;
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
        if(team == TEAM.TEAM_RED)
            Gizmos.color = Color.red;
        else if(team == TEAM.TEAM_BLUE)
            Gizmos.color = Color.blue;
            
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
