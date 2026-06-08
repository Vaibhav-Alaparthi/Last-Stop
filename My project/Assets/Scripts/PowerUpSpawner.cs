using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject coinPrefab;
    public GameObject speedBoostPrefab;
    public GameObject jumpBoostPrefab;
    public GameObject shieldPrefab;

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
        int level = LevelManager.instance.currentLevel;
        int random = Random.Range(0, 10);

        GameObject prefabToSpawn;

        if (random < 6)
        {
            prefabToSpawn = coinPrefab;
        }
        else if (level == 1)
        {
            prefabToSpawn = Random.Range(0, 2) == 0 ? speedBoostPrefab : jumpBoostPrefab;
        }
        else
        {
            int powerup = Random.Range(0, 3);

            if (powerup == 0) prefabToSpawn = speedBoostPrefab;
            else if (powerup == 1) prefabToSpawn = jumpBoostPrefab;
            else prefabToSpawn = shieldPrefab;
        }

        float x = lanes[Random.Range(0, lanes.Length)];
        Instantiate(prefabToSpawn, new Vector3(x, 1.2f, nextSpawnZ), Quaternion.identity);
    }
}