using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager gameManager = default;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            gameManager.PlayerCollidedWithWall();
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playerSegment"))
        {
            gameManager.PlayerCollidedWithPlayerSegment();
        }
    }
}
