using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    private bool IsSelected;
    [SerializeField, Range(0, 100)]
    private float Speed;
    private Vector3 MouseOffset;
    [SerializeField]
    private LayerMask RaycastMask;

    private void FixedUpdate()
    {
        if (!GameManager.CheckIsPainting())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, RaycastMask);

            if (IsSelected && hit.collider != null)
            {
                //transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x - MouseOffset.x, transform.localScale.y / 2, hit.point.z - MouseOffset.z), Time.deltaTime * Speed);
                //transform.position = new Vector3(
                //    hit.point.x - (Mathf.Sin(75 * Mathf.Deg2Rad) * transform.localScale.y / Mathf.Sin(30 * Mathf.Deg2Rad)), 
                //    transform.localScale.y / 2, 
                //    hit.point.z - (Mathf.Sin(75 * Mathf.Deg2Rad) * transform.localScale.y / Mathf.Sin(30 * Mathf.Deg2Rad))
                //);
                transform.position = hit.point;
                transform.position += Vector3.up * transform.localScale.y / 2;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!GameManager.CheckIsPainting())
        {
            IsSelected = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, RaycastMask);

            MouseOffset = hit.point - transform.position;
        }
    }

    private void OnMouseUp()
    {
        if (!GameManager.CheckIsPainting())
        {
            IsSelected = false;

            MouseOffset = Vector3.zero;
        }
    }
}
