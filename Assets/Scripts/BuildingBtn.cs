using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBtn : MonoBehaviour
{
    public BuildingBtn[] buildingBtns;
    public InputController inputController;
    [SerializeField] GameObject building;

    // Start is called before the first frame update
    void Start()
    {
        buildingBtns = FindObjectsOfType<BuildingBtn>();
        inputController = FindObjectOfType<InputController>();
    }

    public void Select() 
    {
        inputController.selectedGO = building;
        inputController.state = new Build_Mode();
    }
}
