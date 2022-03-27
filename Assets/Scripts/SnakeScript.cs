using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    [SerializeField] float frequency;
    [SerializeField] int initialSize;
    [SerializeField] int size;
    [SerializeField] Vector3 direction;

    [Header("Snake Body")]
    [SerializeField] GameObject snakePartPrefab;
    [SerializeField] List<SnakePart> body;
    private SnakePart head;
    private SnakePart tail;

    private bool isAlive = true;

    private void Movement()
    {
        Vector3 lastPosition = head.position;
        Vector3 nextPosition = lastPosition + direction;

        head = tail;
        head.position = nextPosition;
        body.Remove(head);
        body.Insert(0, head);
        tail = body[size - 1];
    }

    private void UpdateRendering()
    {
        head.SetHead();
        body[1].SetMiddle();
        tail.SetTail();
    }

    private IEnumerator SnakeRoutine()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(frequency);

            Movement();
            UpdateRendering();
        }
    }

    private void CreateBody()
    {
        size = initialSize >= 2 ? initialSize : 2;
        body = new List<SnakePart>();

        for (int i = 0; i < size; i++)
        {
            GameObject _GO = Instantiate(snakePartPrefab, transform);
            SnakePart newPart = _GO.GetComponent<SnakePart>();

            newPart.transform.localPosition = Vector3.right * i;

            body.Add(newPart);
        }

        head = body[0];
        tail = body[size - 1];

        UpdateRendering();
    }

    void Start()
    {
        StartCoroutine(SnakeRoutine());
        CreateBody();
    }
}
