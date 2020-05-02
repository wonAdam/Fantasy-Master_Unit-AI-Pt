using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputState : MonoBehaviour
{
    public abstract void Click(InputController inputController, Camera mainCam, GameObject selectedGO);
    public abstract void Move(InputController inputController, Camera mainCam, GameObject selectedGO);

}

public class Build_Mode : InputState
{
    public override void Click(InputController inputController, Camera mainCam, GameObject selectedGO)
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        LayerMask mask = Singleton.singleton.FloorMask;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            Instantiate(selectedGO, hit.point, Quaternion.identity);
            inputController.buildCompleteEvent.OnOccured();
        }
    }

    public override void Move(InputController inputController, Camera mainCam, GameObject selectedGO)
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        LayerMask mask = Singleton.singleton.FloorMask;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            selectedGO.transform.position = hit.point;
        }    
    }

}

public class Control_Mode : InputState
{
    public override void Click(InputController inputController, Camera mainCam, GameObject selectedGO)
    {

    }

    public override void Move(InputController inputController, Camera mainCam, GameObject selectedGO)
    {

    }
}

public class None_Mode : InputState
{
    public override void Click(InputController inputController, Camera mainCam, GameObject selectedGO)
    {

    }

    public override void Move(InputController inputController, Camera mainCam, GameObject selectedGO)
    {

    }
}