using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
