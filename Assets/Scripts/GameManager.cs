using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnManagerPlayerSegments spawnManagerPlayerSegments = default;
    SpawnManagerLoot spawnManagerLoot = default;
    GameObject lastAddedPlayerSegment = default;

    readonly int initialAmountOfLoot = 3;

    void Awake()
    {
        spawnManagerPlayerSegments = GameObject.FindObjectOfType<SpawnManagerPlayerSegments>();
        if (!spawnManagerPlayerSegments)
        {
            Debug.Log("spawnManagerPlayerSegments must not be null.");
        }
        spawnManagerLoot = GameObject.FindObjectOfType<SpawnManagerLoot>();
        if (!spawnManagerLoot)
        {
            Debug.Log("spawnManagerLoot must not be null.");
        }
        lastAddedPlayerSegment = GameObject.FindGameObjectWithTag("player");
        if (!lastAddedPlayerSegment)
        {
            Debug.Log("player must not be null.");
        }
    }

    void Start()
    {
        for (int i = 0; i < initialAmountOfLoot; i++)
        {
            spawnManagerLoot.SpawnLoot();
        }
    }

    public void LootGathered(Loot loot)
    {
        GameObject playerSegment = spawnManagerPlayerSegments.AddPlayerSegment(lastAddedPlayerSegment);
        lastAddedPlayerSegment = playerSegment;
        Destroy(loot.gameObject);
        spawnManagerLoot.SpawnLoot();        
    }

    public void PlayerCollidedWithWall()
    {
        Time.timeScale = 0.0f;
    }
}
