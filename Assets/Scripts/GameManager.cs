using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool IsPainting;

    private GameObject CurrentFurniture;
    private GameObject PreviousFurniture;

    public void SelectFurniture(GameObject obj)
    {
        if (obj != CurrentFurniture)
        {
            PreviousFurniture = CurrentFurniture;
            CurrentFurniture = obj;
            GameObject.FindObjectOfType<RotationUI>().ResetSlider();
            DeselectPrevious();
        }
    }

    public void DeselectPrevious()
    {
        if (PreviousFurniture != null)
        {
            PreviousFurniture.GetComponent<DraggableItem>().DeselectFurniture();
        }
    }

    public GameObject GetSelected()
    {
        return CurrentFurniture;
    }


    public bool CheckIsPainting()
    {
        return IsPainting;
    }

    public void SetIsPainting(bool val)
    {
        IsPainting = val;
    }

    public void RotateItemWithSlider(float newRotation)
    {
        CurrentFurniture.transform.eulerAngles = new Vector3(0, newRotation, 0);
    }
}
