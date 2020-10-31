using UnityEngine;

public class PlayerSegment : MonoBehaviour
{
    GameObject objectToFollow = default;
    Vector3 currentMoveDirection = default;

    void Update()
    {
        if (objectToFollow)
        {
            if (Vector3.Distance(objectToFollow.transform.position, transform.position) > 0.95f)
            {
                currentMoveDirection = objectToFollow.transform.position;
            }
        }
        else
        {
            Debug.Log("objectToFollow does not exist anymore. Player probably hit the wall.");
            Destroy(gameObject);
        }

        currentMoveDirection = new Vector3(Mathf.Round(currentMoveDirection.x), Mathf.Round(currentMoveDirection.y), 0.0f);
        Vector3 movement = (currentMoveDirection - transform.position).normalized * GameplayConstants.PlayerSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void Instantiate(GameObject objectToFollow)
    {
        if (objectToFollow)
        {
            this.objectToFollow = objectToFollow;
        }
        else
        {
            Debug.Log("objectToFollow must not be null.");
        }
    }
}
