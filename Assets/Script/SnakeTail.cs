using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private Transform SnakeHead;
    [SerializeField] private float CircleDiameter;

    [SerializeField] private List<Transform> snakeCircles = new();
    [SerializeField] private List<Vector3> positions = new();

    [SerializeField] private int Length = 1;
    [SerializeField] private Text _text;


    private void Awake()
    {
        positions.Add(SnakeHead.position);
    }

    private void FixedUpdate()
    {
        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }

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
        if (CompareTag("Player"))
        {
            Destroy(snakeCircles[0].gameObject);
            snakeCircles.RemoveAt(0);
            positions.RemoveAt(1);

            Length--;
            _text.text = Length.ToString();

            Debug.Log("задел");
        }
    }
}
