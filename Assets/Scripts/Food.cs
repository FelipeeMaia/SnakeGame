using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int minX;
    [SerializeField] private int maxX;
    [SerializeField] private int minY;
    [SerializeField] private int maxY;

    public void GetEaten()
    {
        gameObject.SetActive(false);
        Respawn();
    }

    private void Respawn()
    {
        Vector3 newPos = Vector3.zero;
        newPos.x = Random.Range(minX, maxX);
        newPos.y = Random.Range(minY, maxY);

        transform.position = newPos;
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        Respawn();
    }
}
