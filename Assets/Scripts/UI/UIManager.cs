using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Catalog, Gameplay, Painting;

    public void ShowCatalog()
    {
        Catalog.SetActive(true);
        Gameplay.SetActive(false);
        Painting.SetActive(false);
    }

    public void ShowGameplay()
    {
        Catalog.SetActive(false);
        Gameplay.SetActive(true);
        Painting.SetActive(false);
    }

    public void ShowPainting()
    {
        Catalog.SetActive(false);
        Gameplay.SetActive(false);
        Painting.SetActive(true);
    }
}
