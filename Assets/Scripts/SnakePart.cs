using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
    [SerializeField] Sprite headSprite;
    [SerializeField] Sprite middleSprite;
    [SerializeField] Sprite tailSprite;

    [SerializeField] SpriteRenderer renderer;

    public Vector3 position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public void SetHead()
    {
        renderer.sprite = headSprite;
    }

    public void SetMiddle()
    {
        renderer.sprite = middleSprite;
    }

    public void SetTail()
    {
        renderer.sprite = tailSprite;
    }
}
