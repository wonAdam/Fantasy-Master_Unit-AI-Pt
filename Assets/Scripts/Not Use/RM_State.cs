using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RM_State : IState
{
    #region Variables
    public enum STATE
    {
        ADVANCE, PURSUE, SHOOT, DEAD
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
    #endregion

    public RM_State(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target, float _visDist, float _shootDist)
    {
        ai = _ai; agent = _agent; anim = _anim; target = _target; visDist = _visDist; shootDist = _shootDist;
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

    public Collider isInVision()
    {
        Collider[] visCollider = Physics.OverlapSphere(ai.transform.position, visDist);
        List<Collider> visColList = new List<Collider>();
        foreach (Collider col in visCollider)
        {
            if (col != ai.GetComponent<Collider>()) visColList.Add(col);
        }

        if (visColList.Count > 0) return visColList[0];
        else return null;
    }
    public Collider isInShootRange()
    {
        Collider[] shootCollider = Physics.OverlapSphere(ai.transform.position, shootDist);
        List<Collider> shootColList = new List<Collider>();
        foreach (Collider col in shootCollider)
        {
            if (col != ai.GetComponent<Collider>()) shootColList.Add(col);
        }

        if (shootColList.Count > 0) return shootColList[0];  
        else return null;
    }

}

public class RM_Advance : RM_State
{
    public RM_Advance(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target, float _visDist, float _shootDist)
         : base(_ai, _agent, _anim, _target, _visDist, _shootDist){}

    public override void Enter()
    {
        //set name of state
        name = STATE.ADVANCE;


        //Animation SetTrigger


        base.Enter();
    }    
    public override void Update()
    {
        //Check for other States
        //cond for Dead     

        //cond for Shoot
        Collider col = isInShootRange();
        if(col != null)
        {
            target = col.transform;
            nextState = new RM_Shoot(ai, agent, anim, target, visDist, shootDist);
            return;
        }
        col = isInVision();
        //cond for Pursue
        if(col != null)
        {
            target = col.transform;
            nextState = new RM_Pursue(ai, agent, anim, target, visDist, shootDist);
            return;
        }
    }

    public override void Exit()
    {
        //Animation ResetTrigger
        base.Exit();
    }
}

public class RM_Shoot : RM_State
{
    public RM_Shoot(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target, float _visDist, float _shootDist)
         : base(_ai, _agent, _anim, _target, _visDist, _shootDist){}
    public override void Enter()
    {
        //set name of state
        name = STATE.SHOOT;


        //Animation SetTrigger
    }    
    public override void Update()
    {
    //Check for other States
        //cond for Advance

        //cond for Pursue

        //cond for Dead    
    }
    public override void Exit()
    {
        //Animation ResetTrigger
    }
}

public class RM_Pursue : RM_State
{
    public RM_Pursue(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target, float _visDist, float _shootDist)
         : base(_ai, _agent, _anim, _target, _visDist, _shootDist){}
    public override void Enter()
    {
        //set name of state
        name = STATE.PURSUE;


        //Animation SetTrigger
    }    
    public override void Update()
    {
    //Check for other States
        //cond for Advance

        //cond for Shoot

        //cond for Dead      
    }
    public override void Exit()
    {
        //Animation ResetTrigger
    }
}

public class RM_Dead : RM_State
{
    public RM_Dead(Transform _ai, NavMeshAgent _agent, Animator _anim, Transform _target, float _visDist, float _shootDist)
         : base(_ai, _agent, _anim, _target, _visDist, _shootDist){}
    public override void Enter()
    {
        //set name of state
        name = STATE.DEAD;


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
