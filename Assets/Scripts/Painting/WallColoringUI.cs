using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColoringUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Walls;
    [SerializeField] private Material FlatColorMat;

    public void ChangeColor(string colorName)
    {
        Material newMat = new Material(FlatColorMat);

        switch (colorName)
        {
            case "Red":
                newMat.SetColor("_Color", Color.red);
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                }
                break;
            case "Yellow":
                newMat.color = Color.yellow;
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                } 
                break;
            case "Green":
                newMat.color = Color.green;
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                }
                break;
            case "Blue":
                newMat.color = Color.blue;
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                }
                break;
            case "Purple":
                newMat.color = new Color(.5f, 0, .5f); // rgb 128, 0, 128
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                }
                break;
            case "Orange":
                newMat.color = new Color(1, 0.392156862745098f, 0); // rgb 255, 100, 0
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                }
                break;
            case "Brown":
                newMat.color = new Color(0.2823529411764706f, 0.1686274509803922f, 0.0431372549019608f); // rgb 72, 43, 11
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                }
                break;
            case "White":
                newMat.color = Color.white;
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                }
                break;
            default:
                newMat.color = Color.white;
                foreach (GameObject wall in Walls)
                {
                    wall.GetComponent<MeshRenderer>().material = newMat;
                }        
                break;
        }
    }
}
