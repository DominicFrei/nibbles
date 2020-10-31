using UnityEngine;

public class SpawnManagerPlayerSegments : MonoBehaviour
{
    [SerializeField] PlayerSegment playerSegmentPrefab = default;

    void Awake()
    {
        if (!playerSegmentPrefab)
        {
            Debug.Log("playerSegmentPrefab must not be null.");
        }
    }

    public GameObject AddPlayerSegment(GameObject objectToFollow)
    {
        // Spawn a new player segment.
        Vector3 spawnLocation = objectToFollow.transform.position;
        //Vector3 roundedSpawnLocation = new Vector3(Mathf.Round(spawnLocation.x), Mathf.Round(spawnLocation.y), Mathf.Round(spawnLocation.z));
        PlayerSegment playerSegment = Instantiate(playerSegmentPrefab, spawnLocation, Quaternion.identity);
        playerSegment.Instantiate(objectToFollow);

        return playerSegment.gameObject;
    }

}
