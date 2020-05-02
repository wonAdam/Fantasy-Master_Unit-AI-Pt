using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

}

public class SpawningBuilding : Building
{
    [SerializeField] GameObject unitToSpawn;
    [SerializeField] Event eventTimerUp;

    public void SpawnUnit()
    {
        GameObject unit = Instantiate(unitToSpawn, transform.position, Quaternion.identity);
        unit.GetComponent<Team>().tEAM = GetComponent<Team>().tEAM;
        unit.GetComponent<Team>().SetTeamColor();
    }
}
