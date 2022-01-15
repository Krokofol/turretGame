using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject rocketPrefab;

    private List<GameObject> rockets = new List<GameObject>();

    [Range(0, 0.5f)]
    public float shotDelay;
    private float m_TimeSinceShot = 0;

    public int ammoLeft = 0;
    public GameObject ammoLeftText;

    // Start is called before the first frame update
    void Start()
    {
        ChangeAmmo(30);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && m_TimeSinceShot >= shotDelay)
        {
            var rotation = transform.rotation;
            var barrelPosition = transform.position;
            var position = new Vector3(
                x: (float) (-2 * Math.Sin(rotation.eulerAngles.z / 180 * Math.PI)) + barrelPosition.x,
                y: (float) (2 * Math.Cos(rotation.eulerAngles.z / 180 * Math.PI)) + barrelPosition.y,
                z: -0.2f
            );
            var rocket = Instantiate(rocketPrefab, position, Quaternion.Euler(rotation.eulerAngles));
            rockets.Add(rocket);
            m_TimeSinceShot = 0;
            ammoLeft--;
        }
        else
        {
            m_TimeSinceShot += Time.deltaTime;
        }
        
        var removeRockets = new List<GameObject>();
        foreach (var rocket in rockets)
        {
            Vector3 point = Camera.current.WorldToViewportPoint(rocket.transform.position);
            if (point.y < 0 || point.y > 1 || point.x > 1 || point.x < 0)
            {
                removeRockets.Add(rocket);
            }
        }

        foreach (var rocket in removeRockets)
        {
            rockets.Remove(rocket);
            Destroy(rocket);
        }
    }

    public void ChangeAmmo(int delta)
    {
        ammoLeft += delta;
        
    }
}
