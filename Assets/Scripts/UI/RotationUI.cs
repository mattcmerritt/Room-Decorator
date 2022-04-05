using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject rotationLabel, removeButton;

    public void RotationSliderChanged(float value)
    {
        GameObject objToRotate = GameObject.FindObjectOfType<GameManager>().GetSelected();
        if (objToRotate != null)
        {
            Furniture furniture = objToRotate.GetComponent<Furniture>();
            objToRotate.transform.eulerAngles = new Vector3(0f, value + furniture.GetYRotation(), 0f);
        }
    }

    public void ResetSlider()
    {
        GameObject selectedObj = GameObject.FindObjectOfType<GameManager>().GetSelected();
        if (selectedObj != null)
        {
            slider.gameObject.SetActive(true);
            rotationLabel.SetActive(true);
            removeButton.SetActive(true);
            Furniture furniture = selectedObj.GetComponent<Furniture>();
            slider.value = selectedObj.transform.eulerAngles.y - furniture.GetYRotation();
        }
        else
        {
            slider.gameObject.SetActive(false);
            rotationLabel.SetActive(false);
            removeButton.SetActive(false);
        }
    }

    public void RemoveSelectedItem()
    {
        GameObject selectedObj = GameObject.FindObjectOfType<GameManager>().GetSelected();
        Destroy(selectedObj);
        GameObject.FindObjectOfType<GameManager>().SelectFurniture(null);
    }
}
