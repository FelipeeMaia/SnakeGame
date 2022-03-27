using System.Collections;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] float frequency;
    [SerializeField] Vector2 direction;

    [Header("References")]
    [SerializeField] SnakeBody body;
    [SerializeField] SnakeInput input;

    private bool isAlive = true;

    private IEnumerator SnakeRoutine()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(frequency);

            direction = input.GetDirection();
            body.MoveBody(direction);
        }
    }

    void Start()
    {
        StartCoroutine(SnakeRoutine());
        body.CreateBody();
    }
}
