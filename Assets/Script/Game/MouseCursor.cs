using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor: MonoBehaviour
{

    [SerializeField] Texture2D CursorImage;

    void Start()
    {
        Cursor.SetCursor(CursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }

}
