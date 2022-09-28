using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    [SerializeField] private Vector2 newDirection = Vector2.left;
    private bool canChangeDirection;

    public Vector2 GetDirection()
    {
        canChangeDirection = true;
        return newDirection;
    }

    private void TryChangeDirection(Vector2 inputDirection)
    {
        if (!canChangeDirection) return;

        Vector2 reversedDirection = newDirection * -1;
        if (inputDirection == newDirection || inputDirection == reversedDirection) return;

        newDirection = inputDirection;
        canChangeDirection = false;
    }

    public void OnUp()
    {
        TryChangeDirection(Vector2.up);
    }

    public void OnDown()
    {
        TryChangeDirection(Vector2.down);
    }

    public void OnLeft()
    {
        TryChangeDirection(Vector2.left);
    }

    public void OnRight()
    {
        TryChangeDirection(Vector2.right);
    }
}
