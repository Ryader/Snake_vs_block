using NTC.Global.Cache;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

internal class HPBlock : NightCache , INightInit
{
    [SerializeField] internal int _hp;

    public int Hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;

            textPro.text = _hp.ToString();

            if (_hp <= 0)
            {
                Destroy(gameObject);
            }

        }
    }

    [SerializeField] internal float _hpF;
    [SerializeField] private SnakeTail snake;
    [SerializeField] private TextMeshPro textPro;
    [SerializeField] private SnakeLenght ballCount;

    [Header("Подключение шейдера")]

    [SerializeField] private Renderer blockRender;
    [SerializeField] private MaterialPropertyBlock blockMaterial;


    public void Init()
    {
        Hp = Random.Range(1, 20);
        _hpF = Hp;
        blockMaterial = new MaterialPropertyBlock();
        blockRender = GetComponent<Renderer>();

        if (CompareTag("Box"))
        {
            blockRender.GetPropertyBlock(blockMaterial);
            blockMaterial.SetFloat("_Float", _hpF / 50f);
            blockRender.SetPropertyBlock(blockMaterial);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (gameObject.CompareTag("Box"))
        {

            if (snake._lengthSnake <= Hp)
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
            snake._record += Hp;
            snake._lengthSnake += Hp;
            for (int i = 0; i < Hp; i++)
            {
                ballCount.AddCircle();
            }
        }

        Hp = 0;
    }

}