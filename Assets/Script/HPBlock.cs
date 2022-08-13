using TMPro;
using UnityEngine;
using NTC.Global.Cache;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

internal class HPBlock : NightCache , INightRun
{
    [SerializeField] internal int _hp;
    [SerializeField] internal float _hpF;
    [SerializeField] private SnakeTail snake;
    [SerializeField] private TextMeshPro textPro;
    [SerializeField] private SnakeLenght ballCount;

    [Header("Подключение шейдера")]

    [SerializeField] private Renderer blockRender;
    [SerializeField] private MaterialPropertyBlock blockMaterial;

    public void Run()
    {
        textPro.text = _hp.ToString();

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }

        if (CompareTag("Box"))
        {
            blockRender.GetPropertyBlock(blockMaterial);
            blockMaterial.SetFloat("_Float", _hpF / 50f);
            blockRender.SetPropertyBlock(blockMaterial);

        }
    }

    private void Awake()
    {
        _hp = Random.Range(1, 20);
        _hpF = _hp;
        blockMaterial = new MaterialPropertyBlock();
        blockRender = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (gameObject.CompareTag("Box"))
        {

            if (snake._lengthSnake <= _hp)
            {
                snake.Dead();
            }

            for (int i = 0; i < _hp; i++)
            {
                ballCount.RemoveCircle();
                snake._lengthSnake--;
            }

        }

        if (gameObject.CompareTag("Eat"))
        {
            snake._record += _hp;
            snake._lengthSnake += _hp;
            for (int i = 0; i < _hp; i++)
            {
                ballCount.AddCircle();
            }
        }

        _hp = 0;
    }
}