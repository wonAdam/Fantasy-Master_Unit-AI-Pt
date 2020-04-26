using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;

public class RM_AI : MonoBehaviour
{

    [SerializeField] float visionDistance = 15f;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] float rotationSpeed = 10f;

    [SerializeField] int damage = 10;
    [SerializeField] ParticleSystem fireVFX;



    private Health health;
    private Transform enemyBase;
    private GameObject target = null;
    private Animator anim;
    private NavMeshAgent agent;
    private bool isDead = false;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        GameObject[] bases = GameObject.FindGameObjectsWithTag("Base");
        foreach(GameObject b in bases)
        {
            if(b.GetComponent<Team>().tEAM != GetComponent<Team>().tEAM) enemyBase = b.transform;
        }
    }

    private void Start() 
    {
    }

    [Task]
    public bool IsInRange()
    {

        int mask = 1 << 8 | 1 << 9;
        Collider[] visCollider = Physics.OverlapSphere(transform.position, visionDistance, mask);
        List<Collider> visColList = new List<Collider>();
        foreach (Collider col in visCollider)
        {
            if (col != GetComponent<Collider>() && col.GetComponent<Health>()) 
                if(!col.GetComponent<Health>().isDead())
                    if(GetComponent<Team>().tEAM != col.GetComponent<Team>().tEAM)
                        visColList.Add(col);
        }

        if (visColList.Count > 0) return true;
        else return false;  
    }

    [Task]
    public void Shoot()
    {
        if(Task.isInspected) Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);

        

        int mask = 1 << 8 | 1 << 9;
        Collider[] shootCollider = Physics.OverlapSphere(transform.position, shootDistance, mask);
        List<Collider> shootColList = new List<Collider>();
        foreach (Collider col in shootCollider)
        {
            if (col != GetComponent<Collider>()) shootColList.Add(col);
        }

        if (shootColList.Count > 0)
        {
            target = shootColList[0].gameObject;

            agent.SetDestination(transform.position);

            Vector3 direction = target.transform.position - transform.position;

            transform.rotation = Quaternion.Slerp(transform.rotation, 
                                                Quaternion.LookRotation(direction, transform.up),
                                                Time.deltaTime * rotationSpeed);


            // shoot animation trigger
            ResetAllAnimTrigger();
            anim.SetTrigger("isShooting");


            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }    
    }

    [Task]
    void Pursue()
    {
        if(Task.isInspected) Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);

        int mask = 1 << 8 | 1 << 9;
        Collider[] visCollider = Physics.OverlapSphere(transform.position, visionDistance, mask);
        List<Collider> visColList = new List<Collider>();
        foreach (Collider col in visCollider)
        {
            if (col != GetComponent<Collider>()) visColList.Add(col);
        }

        if (visColList.Count > 0)
        {
            target = visColList[0].gameObject;

            // Vector3 direction = target.transform.position - transform.position;

            // transform.rotation = Quaternion.Slerp(transform.rotation, 
            //                                     Quaternion.LookRotation(direction, transform.up),
            //                                     Time.deltaTime * rotationSpeed);

            // pursue animation trigger
            agent.SetDestination(target.transform.position);

            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }    
    }

    [Task]
    public void Advance()
    {
        if(Task.isInspected) Task.current.debugInfo = string.Format("t={0:0.00}", Time.time);
        target = null;
        ResetAllAnimTrigger();
        anim.SetTrigger("isAdvance");

        // Vector3 direction = enemyBase.position - transform.position;

        // transform.rotation = Quaternion.Slerp(transform.rotation, 
        //                                         Quaternion.LookRotation(direction, transform.up),
        //                                         Time.deltaTime * rotationSpeed);
        agent.SetDestination(enemyBase.position);

        Task.current.Succeed();
    }

    [Task]
    public void Die()
    {

        agent.SetDestination(transform.position);
        Destroy(gameObject);
        
    }

    private void ResetAllAnimTrigger()
    {
        anim.ResetTrigger("isShooting");
        anim.ResetTrigger("isDead");
        anim.ResetTrigger("isAdvance");
    }

    private void FireVFX()
    {
        fireVFX.Play();
    }
    
    public void SendDamage()
    {
        target?.GetComponent<Health>().DealDamage(damage);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, visionDistance);
        if(GetComponent<Team>().tEAM == Team.TEAM.RED)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, shootDistance);
    }
}
