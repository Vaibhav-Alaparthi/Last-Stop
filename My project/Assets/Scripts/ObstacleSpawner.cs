using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform player;

    public GameObject jumpObstacle;
    public GameObject slideObstacle;
    public GameObject sideObstacle;

    public float spawnDistanceAhead = 70f;
    public float spawnSpacing = 18f;

    private float nextSpawnZ = 40f;

    private float[] lanes = { -3f, 0f, 3f };

    void Update()
    {
        if (player.position.z + spawnDistanceAhead > nextSpawnZ)
        {
            SpawnObstacleSet();
            nextSpawnZ += spawnSpacing;
        }
    }

    void SpawnObstacleSet()
    {
        int level = LevelManager.instance.currentLevel;

        if (level == 1)
        {
            SpawnSingleObstacle(jumpObstacle);
        }
        else if (level == 2)
        {
            int random = Random.Range(0, 2);

            if (random == 0)
            {
                SpawnSingleObstacle(jumpObstacle);
            }
            else
            {
                SpawnSingleObstacle(sideObstacle);
            }
        }
        else
        {
            int random = Random.Range(0, 3);

            if (random == 0)
            {
                SpawnSingleObstacle(jumpObstacle);
            }
            else if (random == 1)
            {
                SpawnSingleObstacle(slideObstacle);
            }
            else
            {
                SpawnTwoSideObstacles();
            }
        }
    }

    void SpawnSingleObstacle(GameObject obstacle)
    {
        float x = lanes[Random.Range(0, lanes.Length)];
        float y = 0.5f;

        if (obstacle == sideObstacle)
        {
            y = 1f;
        }

        if (obstacle == slideObstacle)
        {
            y = 2f;
        }

        Instantiate(obstacle, new Vector3(x, y, nextSpawnZ), Quaternion.identity);
    }

    void SpawnTwoSideObstacles()
    {
        int openLane = Random.Range(0, 3);

        for (int i = 0; i < lanes.Length; i++)
        {
            if (i != openLane)
            {
                Instantiate(sideObstacle, new Vector3(lanes[i], 1f, nextSpawnZ), Quaternion.identity);
            }
        }
    }
}