using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RM_State : IState
{
    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, SLEEP
    };
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };
    public STATE name;
    protected EVENT stage;
    protected Transform ai;
    protected Animator anim;
    protected Transform target;
    protected RM_State nextState;
    protected NavMeshAgent agent;
    protected float visDist;
    protected float shootDist;

    public RM_State(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target)
    {
        ai = _ai; agent = _agent; anim = _anim; target = _target;
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }    
    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public RM_State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;    
    }


}

public class RM_Advance : RM_State
{
    public RM_Advance(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target)
         : base(_ai, _agent, _anim, _target){}

    public override void Enter()
    {
        //Animation SetTrigger
    }    
    public override void Update()
    {
        //Check for other States
    }
    public override void Exit()
    {
        //Animation ResetTrigger
    }
}

public class RM_Shoot : RM_State
{
    public RM_Shoot(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target)
         : base(_ai, _agent, _anim, _target){}
    public override void Enter()
    {
        //Animation SetTrigger
    }    
    public override void Update()
    {
        //Check for other States
    }
    public override void Exit()
    {
        //Animation ResetTrigger
    }
}

public class RM_Pursue : RM_State
{
    public RM_Pursue(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target)
         : base(_ai, _agent, _anim, _target){}
    public override void Enter()
    {
        //Animation SetTrigger
    }    
    public override void Update()
    {
        //Check for other States
    }
    public override void Exit()
    {
        //Animation ResetTrigger
    }
}

public class RM_Dead : RM_State
{
    public RM_Dead(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target)
         : base(_ai, _agent, _anim, _target){}
    public override void Enter()
    {
        //Animation SetTrigger
    }    
    public override void Update()
    {
        //Check for other States
    }
    public override void Exit()
    {
        //Animation ResetTrigger
    }
}
