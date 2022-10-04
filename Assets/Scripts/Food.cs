using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public void GetEaten()
    {
        gameObject.SetActive(false);
        Respawn();
    }

    private void Respawn()
    {
        Vector3 newPos = Vector3.zero;
        newPos.x = Random.Range(GameValues.minX, GameValues.maxX);
        newPos.y = Random.Range(GameValues.minY, GameValues.maxY);

        transform.position = newPos;
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        Respawn();
    }
}
