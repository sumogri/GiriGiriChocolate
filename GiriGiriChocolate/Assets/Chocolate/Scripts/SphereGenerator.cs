using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour {
    static private GameObject spherePrefab;
    private const float cooltimeMin = 2f;
    private const float cooltimeMax = 5f;

    // Use this for initialization
    void Start () {
        if (spherePrefab == null) spherePrefab = GameManager.I.StagePrefabs[0];
        StartCoroutine(GenerateCoroutine());
	}
	
    IEnumerator GenerateCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(cooltimeMin,cooltimeMax));
            var obj = Instantiate(spherePrefab,transform);
            Destroy(obj, 20);
        }
    }
}
