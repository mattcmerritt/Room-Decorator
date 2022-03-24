using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChanger : MonoBehaviour
{
    private string ColorName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public Color changeTheColor()
    {
        ColorName = EventSystem.current.currentSelectedGameObject.name;

        switch (ColorName)
        {
            case "Red":
                Debug.Log("its red");
                return Color.red;
                break;
            case "Yellow":
                Debug.Log("its yellow");
                return Color.yellow;
                break;
            case "Green":
                Debug.Log("its green");
                return Color.green;
                break;
            case "Blue":
                Debug.Log("its blue");
                return Color.blue;
                break;
            case "Purple":
                Debug.Log("its purple");
                return new Color(128, 0, 128);
                break;
            case "Orange":
                Debug.Log("its orange");
                return new Color(255, 165, 0);
                break;
            case "Brown":
                Debug.Log("its blue");
                return new Color(165, 42, 42);
                break;
            case "White":
                Debug.Log("its white");
                return Color.white;
                break;

            default:
                return Color.white;

        }
       // Debug.Log("testing");
      //  Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
