using UnityEngine;

public class PlayerSegment : MonoBehaviour
{
    [SerializeField] GameObject moveTo = default;

    [SerializeField] GameObject transitionElement1 = default;
    [SerializeField] GameObject transitionElement2 = default;

    GameObject objectToFollow = default;

    void Awake()
    {
        if (!moveTo)
        {
            Debug.Log("moveTo must not be null.");
        }
        if (!transitionElement1)
        {
            Debug.Log("moveFrom must not be null.");
        }
        if (!transitionElement2)
        {
            Debug.Log("transitionElement must not be null.");
        }
    }

    void Start()
    {
        moveTo.gameObject.transform.parent = null;
        transitionElement1.gameObject.transform.parent = null;
        transitionElement2.gameObject.transform.parent = null;
    }

    void Update()
    {
        if (Vector3.Distance(objectToFollow.transform.position, transform.position) > 0.95f &&
            Vector3.Distance(moveTo.transform.position, transform.position) < 0.05f)
        {
            moveTo.transform.position = objectToFollow.transform.position;

            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0.0f);
            moveTo.transform.position = new Vector3(Mathf.Round(moveTo.transform.position.x), Mathf.Round(moveTo.transform.position.y), 0.0f);
        }

        Vector3 movement = (moveTo.transform.position - transform.position).normalized * GameplayConstants.PlayerSpeed * Time.deltaTime;
        transform.Translate(movement);

        transitionElement1.transform.position = (objectToFollow.transform.position + moveTo.transform.position) / 2;
        transitionElement2.transform.position = (moveTo.transform.position + transform.position) / 2;
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
