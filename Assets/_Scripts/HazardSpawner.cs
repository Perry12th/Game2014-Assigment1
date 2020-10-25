using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    [SerializeField]
    private HazardManager hazardManager;
    [SerializeField]
    private float respawnTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        hazardManager = GetComponent<HazardManager>();
        StartCoroutine(hazardWaves());
    }

    private void spawnHazard()
    {
        GameObject newHazard = hazardManager.GetHazard(new Vector3(Random.Range(-3, 3), 6.5f));
    }

    IEnumerator hazardWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            if (hazardManager.HasHazards())
            {
                spawnHazard();
            }
        }
    }

   
}
