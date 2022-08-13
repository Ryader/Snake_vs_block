using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;

    public List<Transform> snakeCircles = new();
    public List<Vector3> positions = new();

    [SerializeField] private int Length = 1;
    [SerializeField] private Text _text;

    internal void DeadUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Length++;
            AddCircle();
            _text.text = Length.ToString();
        }
    }

    private void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[^1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);

        Length--;
        _text.text = Length.ToString();

        Debug.Log("задел");
    }

}
