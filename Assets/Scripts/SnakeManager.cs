using System.Collections;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] float frequency;
    [SerializeField] Vector2 direction;

    [Header("References")]
    [SerializeField] SnakeBody snake;
    [SerializeField] SnakeInput input;
    [SerializeField] SnakeSensor sensor;

    private bool isAlive = true;

    private IEnumerator SnakeRoutine()
    {
        yield return new WaitForSeconds(2f);

        while (isAlive)
        {
            yield return new WaitForSeconds(frequency);

            direction = input.GetDirection();

            Vector3 nextPos = direction;
            nextPos += snake.head.position;
            sensedObject ObjectAhead = sensor.LookAhead(nextPos);

            switch (ObjectAhead)
            {
                case sensedObject.food:
                    snake.Eat(direction);
                    break;

                case sensedObject.nothing:
                    snake.MoveBody(direction);
                    break;

                case sensedObject.snake:
                    Death();
                    break;
            }
        }
    }

    private void Death()
    {
        isAlive = false;
    }

    void Start()
    {
        snake.CreateBody();
        StartCoroutine(SnakeRoutine());
        
    }
}
