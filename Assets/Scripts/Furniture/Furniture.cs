using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    // Furniture Properties
    [SerializeField]
    private float YDisplacement;
    [SerializeField]
    private float YRotation;
    [SerializeField]
    private Color PaintColor;
    [SerializeField]
    private string ColorName;
    [SerializeField]
    private string Label;

    [SerializeField, Range(0, 5)]
    private float StepValue;

    /*
    // Child objects - Outdated
    private GameObject MovementUI;
    [SerializeField]
    private GameObject MovementUIPrefab;
    */

    // Painting information
    private bool BeingPainted;

    private void Start()
    {
        /*
        // OUTDATED MOVEMENT UI
        // creating a movement ui for this furniture item
        MovementUI = Instantiate(MovementUIPrefab, Vector3.zero, Quaternion.identity);
        // setting as a child of the furniture item
        MovementUI.transform.SetParent(transform, false);
        // rotating it to go along the floor
        MovementUI.transform.eulerAngles = new Vector3(90f, 0f, 0f);
        // moving the canvas down to the floor but not close enough to have z-fighting
        MovementUI.transform.localPosition += Vector3.down * 0.49f;
        */

        BeingPainted = true;
    }

    public void ChangeColor(Color color, string colorName)
    {
        PaintColor = color;
        ColorName = colorName;
    }

    public void SetLabel(string label)
    {
        Label = label;
    }

    public Color GetColor()
    {
        return PaintColor;
    }

    public string GetColorName()
    {
        return ColorName;
    }

    public string GetLabel()
    {
        return Label;
    }

    public float GetYDisplacement()
    {
        return YDisplacement;
    }

    public float GetYRotation()
    {
        return YRotation;
    }

    /*
    // OLD MOVEMENT CODE
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
        if (!BeingPainted)
        {
            SelectFurniture();
            GameManager.SelectFurniture(gameObject);
        }
    }
    */

    public void ToggleBeingPainted()
    {
        BeingPainted = !BeingPainted;
    }
}
