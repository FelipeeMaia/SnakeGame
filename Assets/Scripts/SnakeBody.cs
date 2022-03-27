using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [SerializeField] int initialSize;
    [SerializeField] GameObject snakePartPrefab;
    [SerializeField] LinkedList<SnakePart> body;

    public void CreateBody()
    {
        int size = initialSize >= 2 ? initialSize : 2;
        body = new LinkedList<SnakePart>();

        for (int i = 0; i < size; i++)
        {
            GameObject _GO = Instantiate(snakePartPrefab, transform);
            SnakePart newPart = _GO.GetComponent<SnakePart>();

            newPart.transform.localPosition = Vector3.right * i;

            body.AddLast(newPart);
        }

        SetSprites();
    }

    public void MoveBody(Vector3 direction)
    {
        SnakePart newHead = body.Last.Value;

        Vector3 newPosition = body.First.Value.position;
        newPosition += direction;

        newHead.position = newPosition;
        newHead.SetDirection(direction);

        body.RemoveLast();
        body.AddFirst(newHead);

        SetSprites();
    }

    private void SetSprites()
    {
        body.First.Value.SetHead();
        body.First.Next.Value.SetMiddle();
        body.Last.Value.SetTail();
    }
}
