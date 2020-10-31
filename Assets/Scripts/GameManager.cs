using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager uiManager = default;
    SpawnManagerPlayerSegments spawnManagerPlayerSegments = default;
    SpawnManagerLoot spawnManagerLoot = default;
    GameObject lastAddedPlayerSegment = default;

    int currentAmountOfLootObjects = default;

    void Awake()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();
        if (!uiManager)
        {
            Debug.Log("uiManager must not be null.");
        }
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
            bool lootSpawned = spawnManagerLoot.SpawnLoot();
            if (!lootSpawned)
            {
                Debug.Log("Initial loot could not be spawned.");
            }
        }
        currentAmountOfLootObjects = GameplayConstants.InitialAmountOfLoot;
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
        bool lootSpawned = spawnManagerLoot.SpawnLoot();
        if (!lootSpawned)
        {
            currentAmountOfLootObjects--;
        }
    }

    public void PlayerCollidedWithWall()
    {
        ShowGameEndingText();
    }

    public void PlayerCollidedWithPlayerSegment()
    {
        ShowGameEndingText();
    }

    void ShowGameEndingText()
    {
        Time.timeScale = 0.0f;
        if (0 == currentAmountOfLootObjects)
        {
            // No loot left, player won the game.
            uiManager.showGameWonText();
        }
        else
        {
            uiManager.showGameOverText();
        }
    }

    public void PlayerClickedRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void PlayerClickedQuit()
    {
        SceneManager.LoadScene("End");
    }

}
