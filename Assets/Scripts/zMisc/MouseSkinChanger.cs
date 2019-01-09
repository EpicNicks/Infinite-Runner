using UnityEngine;

public class MouseSkinChanger : MonoBehaviour {
    public Texture2D mainCursor;  // Your cursor texture
    public Texture2D downCursor;  // Click down texture
 
    void Start()
    {
        Cursor.SetCursor(mainCursor, Vector2.zero, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(downCursor, Vector2.zero, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(mainCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
