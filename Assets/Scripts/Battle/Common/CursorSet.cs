using UnityEngine;

namespace Battle.Common
{
    public class CursorSet : MonoBehaviour
    {
        public Texture2D CursorSprite;
        public Vector2 CursorHotSpot;

        void Start()
        {
            Cursor.SetCursor(CursorSprite, CursorHotSpot, CursorMode.ForceSoftware);
        }
    }
}
