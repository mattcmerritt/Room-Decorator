using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintingArea : MonoBehaviour
{
    [SerializeField]
    private List<string> Names;
    [SerializeField]
    private List<GameObject> FurniturePrefabs;

    private GameObject ActiveObject;

    [SerializeField] 
    private Material FlatColorMat;

    [SerializeField]
    private PlacementHints HintManager;

    public void LoadObject(string name)
    {
        int index = Names.IndexOf(name);
        // creating item
        ActiveObject = Instantiate(FurniturePrefabs[index], Vector3.zero, Quaternion.identity);
        // rotate item toward camera
        ActiveObject.transform.eulerAngles = new Vector3(0, ActiveObject.GetComponent<Furniture>().GetYRotation(), 0);
        // setting as child
        ActiveObject.transform.SetParent(transform);
        // centering
        ActiveObject.transform.localPosition = Vector3.zero;

        // labeling
        ActiveObject.GetComponent<Furniture>().SetLabel(name);
        ActiveObject.GetComponent<Furniture>().ChangeColor(Color.white, "white");
    }


    public void ChangeColor()
    {
        string colorName = EventSystem.current.currentSelectedGameObject.name;

        Material newMat = new Material(FlatColorMat);

        switch (colorName)
        {
            case "Red":
                newMat.SetColor("_Color", Color.red);
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(Color.red, "red");
                break;
            case "Yellow":
                newMat.color = Color.yellow;
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(Color.yellow, "yellow");
                break;
            case "Green":
                newMat.color = Color.green;
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(Color.green, "green");
                break;
            case "Blue":
                newMat.color = Color.blue;
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(Color.blue, "blue");
                break;
            case "Purple":
                newMat.color = new Color(.5f, 0, .5f); // rgb 128, 0, 128
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(new Color(.5f, 0, .5f), "purple");
                break;
            case "Orange":
                newMat.color = new Color(1, 0.392156862745098f, 0); // rgb 255, 100, 0
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(new Color(1, 0.392156862745098f, 0), "orange");
                break;
            case "Brown":
                newMat.color = new Color(0.2823529411764706f, 0.1686274509803922f, 0.0431372549019608f); // rgb 72, 43, 11
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(new Color(0.2823529411764706f, 0.1686274509803922f, 0.0431372549019608f), "brown");
                break;
            case "White":
                newMat.color = Color.white;
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(Color.white, "white");
                break;
            default:
                newMat.color = Color.white;
                ActiveObject.GetComponent<MeshRenderer>().material = newMat;
                ActiveObject.GetComponent<Furniture>().ChangeColor(Color.white, "white");
                break;
        }
    }


    public void AddItemToRoom()
    {
        // detach from paint area
        ActiveObject.transform.SetParent(null);

        // move to room
        ActiveObject.transform.position = Vector3.up * ActiveObject.GetComponent<Furniture>().GetYDisplacement();

        // activate placement click detection
        ActiveObject.GetComponent<Furniture>().ToggleBeingPainted();

        // send new hint if applicable
        HintManager.LookForPlacementHint(ActiveObject.GetComponent<Furniture>());
    }
}
