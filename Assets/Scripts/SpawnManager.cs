using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] PlayerSegment playerSegment = default;

    void Awake()
    {
        if (!playerSegment)
        {
            Debug.Log("Could not retrieve PlayerSegment.");
        }
    }

    public GameObject AddPlayerSegment(GameObject objectToFollow)
    {
        Vector3 spawnLocation = objectToFollow.transform.position;
        Vector3 roundedSpawnLocation = new Vector3(Mathf.Round(spawnLocation.x), Mathf.Round(spawnLocation.y), Mathf.Round(spawnLocation.z));
        PlayerSegment playerSegmentInstance = Instantiate(playerSegment, roundedSpawnLocation, Quaternion.identity);
        playerSegmentInstance.Instantiate(objectToFollow);
        return playerSegmentInstance.gameObject;
    }
}
