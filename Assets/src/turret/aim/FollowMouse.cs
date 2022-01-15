using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
        var mouseScreenPosition = Input.mousePosition;
        var mouseWorldPosition = Camera.current.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z += 8;
        transform.position = mouseWorldPosition;
    }
}
