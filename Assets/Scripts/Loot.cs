using UnityEngine;

public class Loot : MonoBehaviour
{
    GameManager gameManager = default;

    void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (!gameManager)
        {
            Debug.Log("Could not retrieve GameManager.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("player"))
        {
            gameManager.LootGathered();
            Destroy(gameObject);
        }
    }
}
