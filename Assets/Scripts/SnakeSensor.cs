using UnityEngine;

public class SnakeSensor : MonoBehaviour
{
    private Vector3 point;

    public sensedObject LookAhead(Vector3 where)
    {
        point = where;
        var collider = Physics2D.OverlapCircle(where, 0.5f);

        if(collider != null)
        {
            SnakePart snake = collider.GetComponent<SnakePart>();
            if(snake)
            {
                return sensedObject.snake;
            }

            Food food = collider.GetComponent<Food>();
            if (food)
            {
                return sensedObject.food;
            }
        }

        return sensedObject.nothing;
    }
}

public enum sensedObject { snake, food, nothing}
