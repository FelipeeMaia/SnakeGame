using UnityEngine;

public class SnakeSensor : MonoBehaviour
{
    [SerializeField] private float sensorRadius;

    public sensedObject LookAhead(Vector3 where)
    {
        var collider = Physics2D.OverlapCircle(where, sensorRadius);

        if(collider != null)
        {
            string tag = collider.tag;

            if(tag == "Snake")
            {
                return sensedObject.snake;
            }

            if (tag == "Food")
            {
                collider.GetComponent<Food>().GetEaten();
                return sensedObject.food;
            }
        }

        return sensedObject.nothing;
    }
}

public enum sensedObject { snake, food, nothing}
