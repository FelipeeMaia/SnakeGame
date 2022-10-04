using UnityEngine;

public class SnakePart : MonoBehaviour
{
    [SerializeField] Sprite headSprite;
    [SerializeField] Sprite middleSprite;
    [SerializeField] Sprite tailSprite;

    [SerializeField] SpriteRenderer _renderer;

    public Vector3 position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public void SetHead()
    {
        _renderer.sprite = headSprite;
    }

    public void SetMiddle()
    {
        _renderer.sprite = middleSprite;
    }

    public void SetTail()
    {
        _renderer.sprite = tailSprite;
    }

    public void SetDirection(Vector2 direction)
    {
        float angle = 90;

        if (direction == Vector2.right)
            angle += 90;
        else if (direction == Vector2.down)
            angle += 180;
        else if (direction == Vector2.left)
            angle += 270;

        //angle += 90f;
        Vector3 newRotation = Vector3.forward * angle;
        transform.rotation = Quaternion.Euler(newRotation);
    }

    public void KillPart()
    {
        _renderer.color = Color.red;
    }
}
