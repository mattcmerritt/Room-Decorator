using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool IsPainting;

    /*
    // OUTDATED AS OF DRAGGABLE OBJECT
    private static GameObject CurrentFurniture;
    private static GameObject PreviousFurniture;

    public static void SelectFurniture(GameObject obj)
    {
        if (obj != CurrentFurniture)
        {
            PreviousFurniture = CurrentFurniture;
            CurrentFurniture = obj;
            DeselectPrevious();
        }
    }

    public static void DeselectPrevious()
    {
        if (PreviousFurniture != null)
        {
            Furniture furniture = PreviousFurniture.GetComponent<Furniture>();
            furniture.DeselectFurniture();
        }
    }

    public static GameObject GetSelected()
    {
        return CurrentFurniture;
    }
    */

    public static bool CheckIsPainting()
    {
        return IsPainting;
    }

    public static void SetIsPainting(bool val)
    {
        IsPainting = val;
    }
}
