using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    new Camera camera;
    [SerializeField]
    Canvas canvas;
    private void Start()
    {
        StartCameraPosition();
    }

    void StartCameraPosition()
    {
        //hexMap.SetStartCameraPosition();
    }

    void Update()
    {
        Vector3 p = GetBaseInput();
        transform.Translate(p/10);
    }

    private Vector3 GetBaseInput()
    { 
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        return p_Velocity;
    }
}
