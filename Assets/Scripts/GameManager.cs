using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnManager spawnManager = default;
    GameObject lastAddedPlayerSegment = default;

    void Awake()
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        if (!spawnManager)
        {
            Debug.Log("Could not retrieve SpawnManager.");
        }
        lastAddedPlayerSegment = GameObject.FindGameObjectWithTag("player");
        if (!lastAddedPlayerSegment)
        {
            Debug.Log("Could not retrieve Player.");
        }
    }

    public void LootGathered()
    {
        GameObject playerSegment = spawnManager.AddPlayerSegment(lastAddedPlayerSegment);
        lastAddedPlayerSegment = playerSegment;
    }
}
