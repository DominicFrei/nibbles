using UnityEngine;

public class PlayerSegment : MonoBehaviour
{
    GameObject objectToFollow = default;
    Vector3 lastMoveDirection = default;
    float speed = 5.0f;

    void Update()
    {
        if (objectToFollow)
        {
            if (Vector3.Distance(objectToFollow.transform.position, transform.position) > 0.95f)
            {
                lastMoveDirection = objectToFollow.transform.position;
            }
        }
        else
        {
            Debug.Log("objectToFollow does not exist anymore. Player probably hit the wall.");
            Destroy(gameObject);
        }        

        Vector3 movement = (lastMoveDirection - transform.position).normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void Instantiate(GameObject objectToFollow)
    {
        if (!objectToFollow)
        {
            Debug.Log("objectToFollow must not be null.");
        }
        this.objectToFollow = objectToFollow;
    }
}
