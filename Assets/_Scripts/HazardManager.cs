using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject hazard;
    public int MaxHazards;

    private Queue<GameObject> m_HazardPool;

    // Start is called before the first frame update
    void Start()
    {
        _BuildHazardPool();
    }

    private void _BuildHazardPool()
    {
        // create empty Queue structure
        m_HazardPool = new Queue<GameObject>();

        for (int count = 0; count < MaxHazards; count++)
        {
            var tempHazard = Instantiate(hazard);
            tempHazard.transform.parent = transform;
            tempHazard.SetActive(false);
            m_HazardPool.Enqueue(tempHazard);
        }
    }

    public GameObject GetHazard(Vector3 position)
    {
        var newHazard = m_HazardPool.Dequeue();
        newHazard.SetActive(true);
        newHazard.transform.position = position;
        return newHazard;
    }

    public bool HasHazards()
    {
        return m_HazardPool.Count > 0;
    }

    public void ReturnHazard(GameObject returnedHazard)
    {
        returnedHazard.SetActive(false);
        m_HazardPool.Enqueue(returnedHazard);
    }
}
