using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Catalog, Gameplay, Painting, Grading, ClientChat, WallColor;

    [SerializeField]
    private GameObject PaintingArea, MainCamera;

    [SerializeField]
    private GameManager GameManager;

    public void ShowCatalog()
    {
        Catalog.SetActive(true);
        Gameplay.SetActive(false);
        Painting.SetActive(false);
        Grading.SetActive(false);
        ClientChat.SetActive(false);
        WallColor.SetActive(false);

        SwitchToRoom();
    }

    public void ShowGameplay()
    {
        Catalog.SetActive(false);
        Gameplay.SetActive(true);
        Painting.SetActive(false);
        Grading.SetActive(true);
        ClientChat.SetActive(false);
        WallColor.SetActive(false);

        SwitchToRoom();
    }

    public void ShowPainting()
    {
        Catalog.SetActive(false);
        Gameplay.SetActive(false);
        Painting.SetActive(true);
        Grading.SetActive(false);
        ClientChat.SetActive(false);
        WallColor.SetActive(false);

        SwitchToPaintingArea();
    }

    public void ShowClientChat()
    {
        Catalog.SetActive(false);
        Gameplay.SetActive(false);
        Painting.SetActive(false);
        Grading.SetActive(false);
        ClientChat.SetActive(true);
        WallColor.SetActive(false);

        SwitchToRoom();
    }

    public void ShowWallColor()
    {
        Catalog.SetActive(false);
        Gameplay.SetActive(false);
        Painting.SetActive(false);
        Grading.SetActive(false);
        ClientChat.SetActive(false);
        WallColor.SetActive(true);

        SwitchToRoom();
    }

    public void SwitchToPaintingArea()
    {
        MainCamera.SetActive(false);
        PaintingArea.SetActive(true);

        GameManager.SetIsPainting(true);
    }

    public void SwitchToRoom()
    {
        MainCamera.SetActive(true);
        PaintingArea.SetActive(false);

        GameManager.SetIsPainting(false);
    }
}
