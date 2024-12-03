using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{
    private GameObject ObsticleObj;
    private Vector3 ObsticlePos;

    private void Awake()
    {
        StartCoroutine(DrawRain());
        ObsticlePos = ObsticleObj.transform.position;
    }
    private IEnumerator DrawRain()
    {
        while(true)
        {
            ObsticleObj = Instantiate(Resources.Load("Prefab/CannonBallPrefab") as GameObject);
            ObsticlePos = new Vector3(Random.Range(-1.75f, 1.75f), transform.position.y, 0);

            ObsticleObj.transform.position = ObsticlePos;
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}
