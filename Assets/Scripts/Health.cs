using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;

public class Health : MonoBehaviour
{
    [SerializeField] int healthPoint = 100;

    //Animation Event "GiveDamage()"

    public void DealDamage(int damage)
    {
        healthPoint -= damage;
    }    

    [Task]
    public bool isDead()
    {
        if(healthPoint <= 0)
        {
            return true;
        }
        else return false;
    }
}
