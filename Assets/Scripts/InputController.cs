using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    
    public InputState state;
    public GameObject selectedGO;
    private Camera mainCam;
    public Event buildCompleteEvent;

    private void Start() 
    {
        mainCam = FindObjectOfType<Camera>();
        state = new None_Mode();
    }

    private void Update() {
        state.Move(this, mainCam, selectedGO);
        if(Input.GetMouseButtonDown(0))
            state.Click(this, mainCam, selectedGO);
    }

    public void State2None()
    {
        state = new None_Mode();
    }

}
