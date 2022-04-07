using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject MainCam;
    [SerializeField, Range(0, 1)] private float ZoomSpeed;
    [SerializeField, Range(0, 100)] private float RotateSpeed;
    [SerializeField, Range(0, 20)] private float HideDistance;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject Window, Door;

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
        HideWallObstructions();
    }

    private void HideWallObstructions()
    {
        bool hitDoor = false;
        bool hitWindow = false;

        RaycastHit hit1;
        if (Physics.Raycast(Vector3.zero - (MainCam.transform.forward * HideDistance), - (MainCam.transform.forward + MainCam.transform.right), out hit1, 100, 1 << 8))
        {
            //Debug.DrawLine(new Vector3(0f, -1f, 0f) - (MainCam.transform.forward * HideDistance), hit1.point, Color.green, 5f);
            //Debug.Log("Raycast: " + hit1.collider.gameObject.name);
            if(hit1.collider.gameObject.name.Contains("Door"))
            {
                hitDoor = true;
            }
            if (hit1.collider.gameObject.name.Contains("Window"))
            {
                hitWindow = true;
            }
        }
        RaycastHit hit2;
        if (Physics.Raycast(Vector3.zero - (MainCam.transform.forward * HideDistance), -(MainCam.transform.forward - MainCam.transform.right), out hit2, 100, 1 << 8))
        {
            //Debug.DrawLine(new Vector3(0f, -1f, 0f) - (MainCam.transform.forward * HideDistance), hit2.point, Color.green, 5f);
            //Debug.Log("Raycast: " + hit2.collider.gameObject.name);
            if (hit2.collider.gameObject.name.Contains("Door"))
            {
                hitDoor = true;
            }
            if (hit2.collider.gameObject.name.Contains("Window"))
            {
                hitWindow = true;
            }
        }

        Door.GetComponent<MeshRenderer>().enabled = !hitDoor;
        Window.GetComponent<MeshRenderer>().enabled = !hitWindow;
    }
}
