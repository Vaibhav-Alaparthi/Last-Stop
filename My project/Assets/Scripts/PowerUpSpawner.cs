using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject coinPrefab;
    public GameObject speedBoostPrefab;
    public GameObject jumpBoostPrefab;

    public float spawnDistanceAhead = 70f;
    public float spawnSpacing = 25f;

    private float nextSpawnZ = 25f;
    private float[] lanes = { -3f, 0f, 3f };

    void Update()
    {
        if (player.position.z + spawnDistanceAhead > nextSpawnZ)
        {
            SpawnPowerUp();
            nextSpawnZ += spawnSpacing;
        }
    }

    void SpawnPowerUp()
    {
        int random = Random.Range(0, 10);

        GameObject prefabToSpawn;

        if (random < 6)
        {
            prefabToSpawn = coinPrefab;
        }
        else if (random < 8)
        {
            prefabToSpawn = speedBoostPrefab;
        }
        else
        {
            prefabToSpawn = jumpBoostPrefab;
        }

        float x = lanes[Random.Range(0, lanes.Length)];

        Instantiate(prefabToSpawn, new Vector3(x, 1.2f, nextSpawnZ), Quaternion.identity);
    }
}