using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;

public class RM_AI : MonoBehaviour
{
    [SerializeField] float visionDistance = 15f;
    [SerializeField] float shootDistance = 10f;

    [Task]
    public bool IsInRange()
    {

        int mask = 1 << 8 | 1 << 9;
        Collider[] visCollider = Physics.OverlapSphere(transform.position, visionDistance, mask);
        List<Collider> visColList = new List<Collider>();
        foreach (Collider col in visCollider)
        {
            if (col != GetComponent<Collider>()) visColList.Add(col);
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
            // shoot animation trigger
            


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
            // pursue animation trigger


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
        Task.current.Succeed();
    }

    [Task]
    public bool isDead()
    {
        return false;
    }

    [Task]
    public void Die()
    {

    }
    

    //Animation Event "GiveDamage()"
    public void SendDamage()
    {

    }

    public void DealDamage(int damage)
    {

    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, visionDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootDistance);
    }
}
