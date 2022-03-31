using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject MainCam;
    [SerializeField, Range(0, 1)] private float ZoomSpeed;
    [SerializeField, Range(0, 100)] private float RotateSpeed;
    [SerializeField] private GameObject MainCamera;




    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up, RotateSpeed * -Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Vertical") < 0 && MainCamera.transform.position.y < 25)
        {

            MainCamera.transform.position -= MainCamera.transform.forward * ZoomSpeed;
        } 
        else if (Input.GetAxisRaw("Vertical") > 0 && MainCamera.transform.position.y > 4)
        {
            MainCamera.transform.position += MainCamera.transform.forward * ZoomSpeed;
        }
    }
}
