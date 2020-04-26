using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public enum TEAM { RED, BLUE }
    [SerializeField] public TEAM tEAM;
    
    public void SetTeam(bool t)
    {
        if(t)
        {
            tEAM = TEAM.RED;
        }
        else
        {
            tEAM = TEAM.BLUE;
        }
    }
    
}
