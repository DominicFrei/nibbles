using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject currentMoveToReference = default;
    
    Vector3 moveDirection = default;
    readonly float speed = 5.0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw(RectTransform.Axis.Horizontal.ToString());
        float verticalInput = Input.GetAxisRaw(RectTransform.Axis.Vertical.ToString());

        if (horizontalInput != 0.0f)
        {
            Vector3 newMoveTo = Vector3.right * horizontalInput;
            moveDirection = newMoveTo;
        }
        else if (verticalInput != 0.0f)
        {
            Vector3 newMoveTo = Vector3.up * verticalInput;
            moveDirection = newMoveTo;
        }

        // First we adjust the position of the moveTo point if necessary.
        if (Vector3.Distance(currentMoveToReference.transform.position, transform.position) < 0.05f)
        {
            currentMoveToReference.transform.position += moveDirection;
        }

        // At the end we move the player (head) towards the moveTo point.
        Vector3 movement = (currentMoveToReference.transform.position - transform.position).normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

}
