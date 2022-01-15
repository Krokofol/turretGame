using System;
using UnityEngine;

public class Move : MonoBehaviour
{

    [Range(0,10f)]
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var angles = transform.rotation.eulerAngles;
        var deltaPosition = new Vector3(
            (float) -Math.Sin(angles.z / 180 * Math.PI) * speed * Time.deltaTime, 
            (float)  Math.Cos(angles.z / 180 * Math.PI) * speed * Time.deltaTime,
            0
        );
        transform.position += deltaPosition;
    }
}
