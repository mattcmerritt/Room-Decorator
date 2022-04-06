using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColoringUI : MonoBehaviour
{
    [SerializeField] private GameObject Floor;
    [SerializeField] private Material FlatColorMat;

    public void ChangeColor(string colorName)
    {
        Material newMat = new Material(FlatColorMat);

        switch (colorName)
        {
            case "Brown":
                newMat.color = new Color(0.2823529411764706f, 0.1686274509803922f, 0.0431372549019608f); // rgb 72, 43, 11;
                Floor.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "White":
                newMat.color = Color.white;
                Floor.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "Black":
                newMat.color = Color.black;
                Floor.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "Gray":
                newMat.color = Color.gray;
                Floor.GetComponent<MeshRenderer>().material = newMat;
                break;
            default:
                newMat.color = Color.white;
                Floor.GetComponent<MeshRenderer>().material = newMat;
                break;
        }
    }
}
