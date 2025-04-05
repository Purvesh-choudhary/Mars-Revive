using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHeir : MonoBehaviour
{
    [Header("Cursor Settings")]
    public Texture2D crosshairTexture;
    public Vector2 hotspot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        if (crosshairTexture != null)
        {
            Cursor.SetCursor(crosshairTexture, hotspot, cursorMode);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.LogWarning("No crosshair texture assigned!");
        }
    }
}
