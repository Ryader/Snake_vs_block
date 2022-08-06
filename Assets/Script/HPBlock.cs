using UnityEngine;

public class HPBlock : MonoBehaviour
{
    public int HP;
    public SnakeTail _snake;

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (gameObject.CompareTag("Box"))
        {
            _snake.length -= HP;
        }

        if (gameObject.CompareTag("Eat"))
        {
            _snake.length += HP;
        }

        HP = 0;
    }
}