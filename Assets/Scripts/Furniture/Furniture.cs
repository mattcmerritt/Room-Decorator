using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    // Furniture Properties
    private Vector3 Size;
    private Color PaintColor;

    [SerializeField, Range(0, 5)]
    private float StepValue;

    // Child objects
    private GameObject MovementUI;

    private void Start()
    {
        Size = transform.localScale;
        MovementUI = GetComponentInChildren<MovementUI>().gameObject;
        // hiding inactive canvases
        MovementUI.GetComponent<MovementUI>().HideUI();
    }

    public void ChangeColor(Color color)
    {
        PaintColor = color;
    }

    public void MoveForward()
    {
        transform.position += Vector3.forward * StepValue;
    }

    public void MoveBackward()
    {
        transform.position += Vector3.back * StepValue;
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * StepValue;
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * StepValue;
    }

    public void SelectFurniture()
    {
        MovementUI.SetActive(true);
    }

    public void DeselectFurniture()
    {
        MovementUI.SetActive(false);
    }

    public void OnMouseDown()
    {
        SelectFurniture();
        GameManager.SelectFurniture(gameObject);
    }
}
