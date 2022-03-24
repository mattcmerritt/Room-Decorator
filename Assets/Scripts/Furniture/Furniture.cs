using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    // Furniture Properties
    private Vector3 Size;
    private Color PaintColor;

    private void Start()
    {
        Size = transform.localScale;
    }

    public void ChangeColor(Color color)
    {
        PaintColor = color;
    }

    public void Move(Vector3 movement)
    {
        transform.position -= movement;
    }
}
