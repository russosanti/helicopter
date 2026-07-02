using UnityEngine;
using System.Collections;

public class GemSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnGems());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SpawnGems() {
        while (true) {
            // instantiate the gem in this row
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(26, Random.Range(-8, 8), 10), Quaternion.identity);
            
            // pause 7-20 seconds until the next coin spawns
            yield return new WaitForSeconds(Random.Range(7, 20));
        }
    }
}
