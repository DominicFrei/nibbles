using UnityEditor.Experimental;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5.0f;
    [SerializeField] GameObject moveToPoint = default;
    Vector3 lastMovementDirection = default;

    private void Update()
    {
        if (Vector3.Distance(moveToPoint.transform.position, transform.position) < 0.05f)
        {
            float verticalInput = Input.GetAxisRaw(RectTransform.Axis.Vertical.ToString());
            float horizontalInput = Input.GetAxisRaw(RectTransform.Axis.Horizontal.ToString());

            if (horizontalInput != 0.0f)
            {
                Vector3 newMoveTo = new Vector3(horizontalInput, 0.0f, 0.0f);
                moveToPoint.transform.position += newMoveTo;
                lastMovementDirection = newMoveTo;
            }
            else if (verticalInput != 0.0f)
            {
                Vector3 newMoveTo = new Vector3(0.0f, verticalInput, 0.0f);
                moveToPoint.transform.position += newMoveTo;
                lastMovementDirection = newMoveTo;
            }
            else
            {
                moveToPoint.transform.position += lastMovementDirection;
            }

        }

        Vector3 movement = (moveToPoint.transform.position - transform.position).normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

}
