using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] spawnerItems;

    [SerializeField]
    private float spawnerInterval = 2f;

    void Start()
    {
        StartCoroutine(spawnItem(spawnerInterval));
    }

    private IEnumerator spawnItem(float interval)
    {
        yield return new WaitForSeconds(interval);

        if(spawnerItems.Length == 0)
        {
            Debug.LogWarning("Spawner list is empty");
            yield break;   
        }

        GameObject itemToSpawn = spawnerItems[Random.Range(0, spawnerItems.Length)];

        GameObject spawnedItem = Instantiate(
            itemToSpawn,
            new Vector3(Random.Range(-1.9f, 1.9f), Random.Range(-1.8f, 1.8f), 0),
            Quaternion.identity
        );

        Destroy(spawnedItem, 5f);

        StartCoroutine(spawnItem(interval));

        //Instantiate(itemToSpawn, new Vector3(Random.Range(-1.9f, 1.9f), Random.Range(-1.8f, 1.8f), 0), Quaternion.identity);

        //StartCoroutine(spawnItem(interval));
    }
    
}
