using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

internal class SnakeTail : MonoBehaviour
{

    private float horzinotal;
    [Header("Персонаж")]
    [SerializeField] private SnakeLenght snakeLenght;
    [SerializeField] private GameObject snakePlayer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int speed;
    [SerializeField] private int speedTurn;
    [SerializeField] internal int _lengthSnake;

    [Header("UI Элементы")]
    [SerializeField] private Text _text;
    [SerializeField] private Text textRecord;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] internal int _record;

    [Header("Партиклы")]
    [SerializeField] private ParticleSystem particle1;
    [SerializeField] private ParticleSystem particle2;

    [Header("Звук")]
    [SerializeField] private SoundSystem _sound;

    private void Awake()
    {
        snakeLenght.GetComponent<SnakeLenght>();
        _lengthSnake = 1;
        _text.text = _lengthSnake.ToString();

        particle1.Stop();
        particle2.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Finish"))
        {
            speed = 0;
            speedTurn = 0;

            _sound.Victory();
            victoryPanel.SetActive(true);

            particle1.Play();
            particle2.Play();
        }

        if (collision.gameObject.CompareTag("Box"))
        {
            _sound.Hit();
        }

        if (collision.gameObject.CompareTag("Eat"))
        {
            _sound.Score();
        }
    }

    private void Update()
    {

        textRecord.text = _record.ToString();
        _text.text = _lengthSnake.ToString();

        //Управление
        if (_lengthSnake >= 1)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            horzinotal = Input.GetAxis("Horizontal");
            transform.Translate(speedTurn * horzinotal * Time.deltaTime * Vector3.right);

            if (transform.position.x < -10)
            {
                transform.position = new Vector3(-10, transform.position.y, transform.position.z);
            }

            if (transform.position.x > 10)
            {
                transform.position = new Vector3(10, transform.position.y, transform.position.z);
            }
        }

        snakeLenght.TailLenght();

        if (_lengthSnake <= 0)
        {
            Dead();
        }
    }

    internal void Dead()
    {
        speed = 0;
        speedTurn = 0;
        Destroy(snakePlayer);
        _text.gameObject.SetActive(false);
        losePanel.SetActive(true);
        _sound.Dead();
    }
}
