using UnityEngine;
using UnityEngine.UI;

public class SnakeTail : MonoBehaviour
{
    private float horzinotal;
    [SerializeField] private GameObject snake;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int length = 1;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject losePanel;


    private void Awake()
    {
        length = 1;
        _text.text = length.ToString();
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            length++;
            _text.text = length.ToString();
        }


        //Управление
        if (length >= 1)
        {
            transform.Translate(0, 0, 10 * Time.deltaTime);

            horzinotal = Input.GetAxis("Horizontal");
            transform.Translate(30 * horzinotal * Time.deltaTime * Vector3.right);

            if (transform.position.x < -10)
            {
                transform.position = new Vector3(-10, transform.position.y, transform.position.z);
            }

            if (transform.position.x > 10)
            {
                transform.position = new Vector3(10, transform.position.y, transform.position.z);
            }
        }
        //смерть
        else if (length <= 0)
        {
            transform.Translate(0, 0, 0 * Time.deltaTime);
            Destroy(snake);
            _text.gameObject.SetActive(false);
            losePanel.SetActive(true);
        }
    }



    //Получение урона 

    private void OnTriggerStay(Collider other)
    {
        if (CompareTag("Player"))
        {
            length--;
            _text.text = length.ToString();
            Debug.Log("задел");
        }
    }
}
