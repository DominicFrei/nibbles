using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] PlayerSegment playerSegmentPrefab = default;
    [SerializeField] Loot lootPrefab = default;

    int playingFieldBoundsLeft = -8;
    int playingFieldBoundsRight = 8;
    int playingFieldBoundsUpper = 4;
    int playingFieldBoundsLower = -4;

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
        int randomX = Random.Range(playingFieldBoundsLeft, playingFieldBoundsRight + 1);
        int randomY = Random.Range(playingFieldBoundsLower, playingFieldBoundsUpper + 1);
        Vector3 lootSpawnPosition = new Vector3(randomX, randomY, 0.0f);
        Debug.Log("Spawning loot at: " + lootSpawnPosition);
        _ = Instantiate(lootPrefab, lootSpawnPosition, Quaternion.identity);
    }

}
