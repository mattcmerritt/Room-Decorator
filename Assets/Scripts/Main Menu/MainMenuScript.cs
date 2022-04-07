using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Elements;

    public void ActivateGameElements()
    {
        foreach (GameObject element in Elements)
        {
            element.SetActive(true);
        }

        Destroy(gameObject);
    }

    public void LoadRoomScene()
    {
        SceneManager.LoadScene("Room");
        Debug.Log("ur in loadRoomScene");
    }

}
