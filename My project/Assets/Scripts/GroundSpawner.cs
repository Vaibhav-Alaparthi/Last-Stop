using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public Transform player;

    public float tileLength = 10f;
    public int tilesAhead = 8;

    private float spawnZ = 0f;
    private List<GameObject> spawnedTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < tilesAhead; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z + (tilesAhead * tileLength) > spawnZ)
        {
            SpawnTile();
        }

        if (spawnedTiles.Count > tilesAhead + 2)
        {
            Destroy(spawnedTiles[0]);
            spawnedTiles.RemoveAt(0);
        }
    }

    void SpawnTile()
    {
        GameObject tile = Instantiate(groundPrefab, new Vector3(0f, 0f, spawnZ), Quaternion.identity);
        spawnedTiles.Add(tile);
        spawnZ += tileLength;
    }
}