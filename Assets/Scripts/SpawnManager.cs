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
        int randomX = Random.Range(playingFieldBoundsLeft - 1, playingFieldBoundsRight + 1);
        int randomY = Random.Range(playingFieldBoundsLower - 1, playingFieldBoundsUpper + 1);
        Vector3 lootSpawnPosition = new Vector3(randomX, randomY, 0.0f);
        Instantiate(lootPrefab, lootSpawnPosition, Quaternion.identity);
    }

    public GameObject AddPlayerSegment(GameObject objectToFollow)
    {
        // Spawn a new player segment.
        Vector3 spawnLocation = objectToFollow.transform.position;
        Vector3 roundedSpawnLocation = new Vector3(Mathf.Round(spawnLocation.x), Mathf.Round(spawnLocation.y), Mathf.Round(spawnLocation.z));
        PlayerSegment playerSegmentInstance = Instantiate(playerSegmentPrefab, roundedSpawnLocation, Quaternion.identity);
        playerSegmentInstance.Instantiate(objectToFollow);

        // Spawn a new loot object.


        return playerSegmentInstance.gameObject;
    }

}
