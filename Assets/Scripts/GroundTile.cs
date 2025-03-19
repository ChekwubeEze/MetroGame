using Assets.Scripts;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    FloorSpawner floorSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floorSpawner = GameObject.FindObjectOfType<FloorSpawner>();
        SpawnBooster();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject boosterPrefab;
    void SpawnBooster()
    {
        //choose a random point to spawn the booster
        int boosterSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(boosterSpawnIndex).transform;

        //Spawn the booster at the position
        Instantiate(boosterPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
