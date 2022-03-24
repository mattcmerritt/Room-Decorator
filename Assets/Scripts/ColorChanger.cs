using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour
{
    private string ColorName;
    [SerializeField] private Material FlatColorMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void changeTheColor()
    {
        ColorName = EventSystem.current.currentSelectedGameObject.name;

        Material newMat = new Material(FlatColorMat);

        switch (ColorName)
        {
            case "Red":
                Debug.Log("its red");
                newMat.SetColor("_Color", Color.red);
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "Yellow":
                Debug.Log("its yellow");
                newMat.color = Color.yellow;
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "Green":
                Debug.Log("its green");
                newMat.color = Color.green;
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "Blue":
                Debug.Log("its blue");
                newMat.color = Color.blue;
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "Purple":
                Debug.Log("its purple");
                newMat.color = new Color(.5f, 0, .5f); // rgb 128, 0, 128
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "Orange":
                Debug.Log("its orange");
                newMat.color = new Color(1, 0.392156862745098f, 0); // rgb 255, 100, 0
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "Brown":
                Debug.Log("its brown");
                newMat.color = new Color(0.2823529411764706f, 0.1686274509803922f, 0.0431372549019608f); // rgb 72, 43, 11
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;
            case "White":
                Debug.Log("its white");
                newMat.color = Color.white;
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;

            default:
                newMat.color = Color.white;
                gameObject.GetComponent<MeshRenderer>().material = newMat;
                break;

        }
       // Debug.Log("testing");
      //  Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
