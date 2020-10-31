using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnManagerPlayerSegments spawnManagerPlayerSegments = default;
    SpawnManagerLoot spawnManagerLoot = default;
    GameObject lastAddedPlayerSegment = default;    

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
        for (int i = 0; i < GameplayConstants.InitialAmountOfLoot; i++)
        {
            spawnManagerLoot.SpawnLoot();
        }
    }

    public void LootGathered(Loot loot)
    {
        GameObject playerSegment = spawnManagerPlayerSegments.AddPlayerSegment(lastAddedPlayerSegment);

        // The first two segment need different tags to make sure we can distinguish them since they easily
        // have contact with the head element and would end in an unwanted collision.
        if (lastAddedPlayerSegment.CompareTag("player"))
        {
            playerSegment.tag = "firstPlayerSegment";
        }
        else if (lastAddedPlayerSegment.CompareTag("firstPlayerSegment"))
        {
            playerSegment.tag = "secondPlayerSegment";
        }
        lastAddedPlayerSegment = playerSegment;
        Destroy(loot.gameObject);
        spawnManagerLoot.SpawnLoot();        
    }

    public void PlayerCollidedWithWall()
    {
        // TODO: For now we just stop the game. Add a RESTART (R) and END GAME (Q or E) option.
        Time.timeScale = 0.0f;
    }

    public void PlayerCollidedWithPlayerSegment()
    {
        Time.timeScale = 0.0f;
    }
}
