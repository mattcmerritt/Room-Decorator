using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MovementUI : MonoBehaviour
{
    /*
    // OUTDATED, SEE DRAGGABLE ITEM
    private void Start()
    {
        // world space canvases need to be set up with the camera
        Canvas canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        // adding the onClick handlers to the button
        Button[] buttons = GetComponentsInChildren<Button>();

        Dictionary<string, UnityAction> behaviorSet = new Dictionary<string, UnityAction>();
        behaviorSet.Add("left", () => GetComponentInParent<Furniture>().MoveLeft());
        behaviorSet.Add("right", () => GetComponentInParent<Furniture>().MoveRight());
        behaviorSet.Add("forward", () => GetComponentInParent<Furniture>().MoveForward());
        behaviorSet.Add("backward", () => GetComponentInParent<Furniture>().MoveBackward());

        foreach (Button b in buttons)
        {
            foreach (string key in behaviorSet.Keys)
            {
                if (b.name.ToLower().Contains(key))
                {
                    behaviorSet.TryGetValue(key, out UnityAction act);
                    b.onClick.AddListener(act);
                }
            }
        }

        // hiding inactive canvases
        HideUI();
    }

    public void HideUI()
    {
        gameObject.SetActive(false);
    }
    */
}
