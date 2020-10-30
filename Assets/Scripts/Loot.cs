using UnityEngine;

public class Loot : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("player"))
        {
            Destroy(gameObject);
        }
    }
}
