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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();


        //Initial State
        currentState = new RM_Advance(transform, agent, anim, target);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
