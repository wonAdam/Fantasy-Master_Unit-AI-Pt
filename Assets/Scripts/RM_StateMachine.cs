using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RM_StateMachine : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Transform target = null;
    RM_State currentState;
    [SerializeField] float visDis;
    [SerializeField] float shootDis;


    //debug
    public RM_State.STATE state;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        //Initial State
        currentState = new RM_Advance(transform, agent, anim, target, visDis, shootDis);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
        state = currentState.name;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, visDis);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootDis);
    }
}
