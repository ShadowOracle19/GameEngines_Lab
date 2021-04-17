using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private int NumberOfZombiesToSpawn;

    [SerializeField] private GameObject[] zombiePrefab;

    [SerializeField] private SpawnerVolume[] spawnerVolumes;

    private GameObject FollowGameObject;

    // Start is called before the first frame update
    void Start()
    {
        FollowGameObject = GameObject.FindGameObjectWithTag("Player");
        for(int index = 0; index < NumberOfZombiesToSpawn; index++)
        {
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefab[Random.Range(0, zombiePrefab.Length)];
        SpawnerVolume spawnerVolume = spawnerVolumes[Random.Range(0, spawnerVolumes.Length)];

        if (!FollowGameObject) return;

        GameObject zombie = Instantiate(zombieToSpawn,
                spawnerVolume.GetPositionInBounds(),
                spawnerVolume.transform.rotation);

        zombie.GetComponent<ZombieComponent>().Initalize(FollowGameObject);
    }
}
