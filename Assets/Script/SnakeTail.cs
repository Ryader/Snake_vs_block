using UnityEngine;
using UnityEngine.UI;
internal class SnakeTail : MonoBehaviour
{

    private float horzinotal;
    [Header("Персонаж")]
    [SerializeField] private GameObject snakePlayer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] internal int lengthSnake;
    [SerializeField] private int speed;
    [SerializeField] private int speedTurn;
    [Header("UI Элементы")]
    [SerializeField] private Text _text;
    [SerializeField] private Text textRecord;
    [SerializeField] internal int record;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject losePanel;
    [Header("Звук")]
    [SerializeField] private SoundSystem _sound;

    private void Awake()
    {
        lengthSnake = 1;
        _text.text = lengthSnake.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Finish"))
        {
            speed = 0;
            speedTurn = 0;

            _sound.Victory();
            victoryPanel.SetActive(true);
            Debug.Log("Победа");
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
        textRecord.text = record.ToString();
        _text.text = lengthSnake.ToString();
        Debug.Log(textRecord);
        //Управление
        if (lengthSnake >= 1)
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
        
        if (lengthSnake <= 0)
        {
            speed = 0;
            speedTurn = 0;
            Destroy(snakePlayer);
            _text.gameObject.SetActive(false);
            losePanel.SetActive(true);
            _sound.Dead();
        }
    }
}
