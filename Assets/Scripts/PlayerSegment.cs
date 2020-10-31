using UnityEngine;

public class PlayerSegment : MonoBehaviour
{
    [SerializeField] GameObject moveTo = default;
    GameObject objectToFollow = default;

    void Start()
    {
        moveTo.gameObject.transform.parent = null;
    }

    void Update()
    {
        if (!objectToFollow)
        {
            Debug.Log("objectToFollow does not exist anymore. Player probably hit the wall.");
            Destroy(gameObject);
            return;
        }

        if (Vector3.Distance(objectToFollow.transform.position, transform.position) > 0.95f &&
            Vector3.Distance(moveTo.transform.position, transform.position) < 0.05f)
        {
            moveTo.transform.position = objectToFollow.transform.position;
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0.0f);
            moveTo.transform.position = new Vector3(Mathf.Round(moveTo.transform.position.x), Mathf.Round(moveTo.transform.position.y), 0.0f);
        }

        Vector3 movement = (moveTo.transform.position - transform.position).normalized * GameplayConstants.PlayerSegmentSpeed * Time.deltaTime;
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
