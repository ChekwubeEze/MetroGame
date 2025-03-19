using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class FloorSpawner: MonoBehaviour
    {
        public GameObject groundTile;
        Vector3 nextSpawnPoint;
        public void SpawnTile()
        {
            GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }
        void Start()
        {
            for (int i = 0; i < 15; i++)
            {
                SpawnTile();
                SpawnBooster();
            }
        }
        public GameObject boosterPrefab;
        void SpawnBooster()
        {
            //choose a random point to spawn the boosterPrefab
            int obstacleSpawnIndex = Random.Range(1, 2);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            ////Spawn the boosterPrefab at the position
            Instantiate(boosterPrefab, spawnPoint.position, Quaternion.identity, transform);
        }
    }
}
