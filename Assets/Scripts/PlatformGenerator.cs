using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    private List<GameObject> activePlatform = new List<GameObject>();
    private float spawnPos = 0;
    private float platformLenght = 100f;
    private int startPlatform = 4;
    [SerializeField] private Transform player;


    private void Start()
    {
        for (int i = 0; i < startPlatform; i++)
        {
            if (i == 0)
            {
                SpawnPlatform(4);
            }
            SpawnPlatform(Random.Range(0,platformPrefabs.Length));
        }
    }
    private void Update()
    {
        if (player.position.z - 60  > spawnPos - (startPlatform * platformLenght))
        {
            SpawnPlatform(Random.Range(0, platformPrefabs.Length));
            DeletePlatform();
        }
    }
    private void SpawnPlatform(int platformIndex)
    {
        GameObject nextPlatform = Instantiate(platformPrefabs[platformIndex], transform.forward * spawnPos, transform.rotation);
        activePlatform.Add(nextPlatform);
        spawnPos += platformLenght;
    }
    private void DeletePlatform()
    {
        Destroy(activePlatform[0]);
        activePlatform.RemoveAt(0);
    }    
}
