using UnityEngine;
using UnityEngine.InputSystem;

public class TouchController : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private Vector2 touchDirection;
    private bool isMoving = false;

    public float moveSpeed = 5.0f;

    private void Update()
    {
        if (isMoving)
        {
            Vector3 move = new Vector3(touchDirection.x, 0, touchDirection.y) * moveSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    public void OnTouchStart(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isMoving = true;
            touchStartPosition = context.ReadValue<Vector2>();
        }
    }

    public void OnTouchEnd(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isMoving = false;
        }
    }

    public void OnTouchMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            touchEndPosition = context.ReadValue<Vector2>();
            touchDirection = (touchEndPosition - touchStartPosition).normalized;
        }
    }
}
