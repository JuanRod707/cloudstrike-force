using UnityEngine;

public class CursorSet : MonoBehaviour
{
    public Texture2D CursorSprite;
    public Vector2 CursorHotSpot;

    void Start()
    {
        Cursor.SetCursor(CursorSprite, CursorHotSpot, CursorMode.ForceSoftware);
    }
}
