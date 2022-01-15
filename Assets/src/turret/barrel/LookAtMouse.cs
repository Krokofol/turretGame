using System;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouseScreenPosition = Input.mousePosition;
        var mouseWorldPosition = Camera.current.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z += 10;
        transform.LookAt(mouseWorldPosition);
        var angles = transform.rotation.eulerAngles;
        angles.y -= 180;
        angles.z = (180 - angles.x + 90) * Math.Sign(angles.y) * -1;
        angles.y = 0;
        angles.x = 0;
        transform.rotation = Quaternion.Euler(angles);
    }
}
