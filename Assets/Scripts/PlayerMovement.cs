using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject currentMoveToReference = default;

    Vector3 nextMoveDirection = default;
    Vector3 lastUsedMoveDirection = default;

    void Start()
    {
        currentMoveToReference.transform.position = transform.position;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw(RectTransform.Axis.Horizontal.ToString());
        float verticalInput = Input.GetAxisRaw(RectTransform.Axis.Vertical.ToString());

        if (horizontalInput != 0.0f && lastUsedMoveDirection != Vector3.right && lastUsedMoveDirection != Vector3.left)
        {
            Vector3 newMoveTo = Vector3.right * horizontalInput;
            nextMoveDirection = newMoveTo;
        }
        else if (verticalInput != 0.0f && lastUsedMoveDirection != Vector3.up && lastUsedMoveDirection != Vector3.down)
        {
            Vector3 newMoveTo = Vector3.up * verticalInput;
            nextMoveDirection = newMoveTo;
        }

        // First we adjust the position of the moveTo point if necessary.
        if (Vector3.Distance(currentMoveToReference.transform.position, transform.position) < 0.05f)
        {
            currentMoveToReference.transform.position += nextMoveDirection;
            lastUsedMoveDirection = nextMoveDirection;
        }

        // At the end we move the player (head) towards the moveTo point.
        Vector3 movement = (currentMoveToReference.transform.position - transform.position).normalized * GameplayConstants.PlayerSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

}
