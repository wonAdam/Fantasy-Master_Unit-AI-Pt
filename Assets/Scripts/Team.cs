using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public enum TEAM { RED, BLUE }
    [SerializeField] public TEAM tEAM;

    private void Start() 
    {
        SetTeamColor();
    }

    public void SetTeamColor()
    {
        Base[] bs = FindObjectsOfType<Base>();
        foreach(Base b in bs)
        {
            if(b.GetComponent<Team>().tEAM == tEAM)
                GetComponent<MeshRenderer>().material = b.GetComponent<MeshRenderer>().material;
        }
    } 

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
