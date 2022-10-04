using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    [SerializeField] int initialSize;
    [SerializeField] GameObject snakePartPrefab;
    [SerializeField] LinkedList<SnakePart> body;
    public SnakePart head;

    public void CreateBody()
    {
        int size = initialSize >= 2 ? initialSize : 2;
        body = new LinkedList<SnakePart>();

        GameObject _GO = Instantiate(snakePartPrefab, transform);
        head = _GO.GetComponent<SnakePart>();
        body.AddFirst(head);

        for (int i = 1; i < size; i++)
        {
            _GO = Instantiate(snakePartPrefab, transform);
            SnakePart newPart = _GO.GetComponent<SnakePart>();

            newPart.transform.localPosition = Vector3.right * i;

            body.AddLast(newPart);
        }

        head = body.First.Value;
        SetSprites();
    }

    public void MoveBody(Vector3 direction)
    {
        SnakePart newHead = body.Last.Value;
        body.RemoveLast();

        SetNewHead(newHead, direction);
    }

    public void Eat(Vector3 direction)
    {
        GameObject _GO = Instantiate(snakePartPrefab, transform);
        SnakePart newHead = _GO.GetComponent<SnakePart>();

        SetNewHead(newHead, direction);
    }

    private void SetNewHead(SnakePart newHead, Vector3 direction)
    {
        Vector3 newPosition = head.position;
        newPosition += direction;

        if (newPosition.x < GameValues.minX) newPosition.x = GameValues.maxX;
        if (newPosition.x > GameValues.maxX) newPosition.x = GameValues.minX;
        if (newPosition.y < GameValues.minY) newPosition.y = GameValues.maxY;
        if (newPosition.y > GameValues.maxY) newPosition.y = GameValues.minY;

        newHead.position = newPosition;
        newHead.SetDirection(direction);

        body.AddFirst(newHead);
        head = newHead;

        SetSprites();
    }

    private void SetSprites()
    {
        body.First.Value.SetHead();
        body.First.Next.Value.SetMiddle();
        body.Last.Value.SetTail();
    }
}
