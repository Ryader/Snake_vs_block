using UnityEngine;

internal class HPBlock : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private SnakeTail _snake;

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
            _snake.lengthSnake -= HP;
        }

        if (gameObject.CompareTag("Eat"))
        {
            _snake.record += HP;
            _snake.lengthSnake += HP;
        }

        HP = 0;
    }
}