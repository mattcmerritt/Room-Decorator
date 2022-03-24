using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingArea : MonoBehaviour
{
    [SerializeField]
    private List<string> Names;
    [SerializeField]
    private List<GameObject> FurniturePrefabs;

    public void LoadObject(string name)
    {
        int index = Names.IndexOf(name);
        Debug.Log(Names[index] + " " + FurniturePrefabs[index].name);
    }
}
