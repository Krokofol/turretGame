using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealsInterface : MonoBehaviour
{
    [SerializeField, Range(0, 6)]
    public int health;

    [SerializeField]
    public GameObject healthPointPrefab;
    
    [SerializeField]
    private List<GameObject> m_HealthPoints = new List<GameObject>();
    [SerializeField]
    private Vector3 m_HealthPointStartPosition = new Vector3(-7f, -4.25f, -0.1f);
    
    [SerializeField, Range(0,1)]
    private float dx;

    void Start()
    {
        for (int iteration = 0; iteration < health; iteration++)
        {
            var healthPoint = Instantiate(healthPointPrefab, CalculatePosition(), new Quaternion());
            m_HealthPoints.Add(healthPoint);
        }
    }

    private Vector3 CalculatePosition()
    {
        var position = m_HealthPointStartPosition;
        position.x += m_HealthPoints.Count * dx;
        return position;
    }

    void Update()
    {
        if (health < m_HealthPoints.Count)
        {
            for (int i = 0; i < m_HealthPoints.Count - health; i++) {
                DeleteHealthPoint();
            }
        }

        if (health > m_HealthPoints.Count)
        {
            for (int i = 0; i < health - m_HealthPoints.Count; i++) {
                AddHealthPoint();
            }
        }
    }

    public void AddHealthPoint()
    {
        var healthPoint = Instantiate(healthPointPrefab, CalculatePosition(), new Quaternion());
        m_HealthPoints.Add(healthPoint);
    }

    public bool DeleteHealthPoint()
    {
        var healthPoint = m_HealthPoints.Last();
        m_HealthPoints.Remove(healthPoint);
        Destroy(healthPoint);
        return health == 0;
    }
}
