using UnityEngine;

public class PlayerSegment : MonoBehaviour
{
    GameObject objectToFollow = default;

    public void Instantiate(GameObject objectToFollow)
    {
        this.objectToFollow = objectToFollow;
    }
}
