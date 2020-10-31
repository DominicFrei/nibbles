using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] PlayerSegment playerSegmentPrefab = default;
    [SerializeField] Loot lootPrefab = default;

    int playingFieldBoundsLeft = 0;
    int playingFieldBoundsRight = 16;
    int playingFieldBoundsUpper = 8;
    int playingFieldBoundsLower = 0;

    void Awake()
    {
        if (!playerSegmentPrefab)
        {
            Debug.Log("Could not retrieve PlayerSegment.");
        }
    }

    void Start()
    {
        SpawnLoot();
        SpawnLoot();
    }

    public GameObject AddPlayerSegment(GameObject objectToFollow)
    {
        // Spawn a new player segment.
        Vector3 spawnLocation = objectToFollow.transform.position;
        Vector3 roundedSpawnLocation = new Vector3(Mathf.Round(spawnLocation.x), Mathf.Round(spawnLocation.y), Mathf.Round(spawnLocation.z));
        PlayerSegment playerSegmentInstance = Instantiate(playerSegmentPrefab, roundedSpawnLocation, Quaternion.identity);
        playerSegmentInstance.Instantiate(objectToFollow);

        // Spawn a new loot object.
        SpawnLoot();

        return playerSegmentInstance.gameObject;
    }

    void SpawnLoot()
    {
        List<Vector3> availablePositions = GenerateMapWithUnoccupiedPostions();
        if (availablePositions.Count != 0)
        {
            int randomLocationIndex = UnityEngine.Random.Range(0, availablePositions.Count);
            Vector3 lootSpawnPosition = availablePositions[randomLocationIndex];
            Debug.Log("Spawning loot at: " + lootSpawnPosition);
            _ = Instantiate(lootPrefab, lootSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("No unoccupied positions left. Player won.");
        }
    }

    // Creates a new map (2-dimensional array) with the playing field which will be used to check
    // if a position is already used or not in order to spawn loot only at unoccupied positions.
    List<Vector3> GenerateMapWithUnoccupiedPostions()
    {
        int width = playingFieldBoundsRight - playingFieldBoundsLeft + 1;
        int height = playingFieldBoundsUpper - playingFieldBoundsLower + 1;

        List<Vector3> availablePositions = new List<Vector3>();

        for (int i = 0; i < width + 1; i++)
        {
            for (int j = 0; j < height + 1; j++)
            {
                Vector3 position = new Vector3(i, j, 0.0f);
                Collider[] otherObjectsInSpawnLocation = Physics.OverlapSphere(position, 0.25f);
                bool positionIsUnoccupied = otherObjectsInSpawnLocation.Length == 0;
                if (positionIsUnoccupied)
                {
                    availablePositions.Add(position);
                }
            }
        }
        return availablePositions;
    }

}
