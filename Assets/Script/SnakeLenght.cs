using System.Collections.Generic;
using NTC.Global.Cache;
using UnityEngine;


internal class SnakeLenght : NightCache , INightInit
{
    [SerializeField] private Transform SnakeHead;
    [SerializeField] private float CircleDiameter;

    [SerializeField] internal List<Transform> _snakeCircles = new();
    [SerializeField] internal List<Vector3> _positions = new();


    public void Init()
    {
        _positions.Add(SnakeHead.position);
    }

    internal void TailLenght()
    {

        float distance = (SnakeHead.position - _positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = (SnakeHead.position - _positions[0]).normalized;

            _positions.Insert(0, _positions[0] + direction * CircleDiameter);
            _positions.RemoveAt(_positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < _snakeCircles.Count; i++)
        {
            _snakeCircles[i].position = Vector3.Lerp(_positions[i + 1], _positions[i], distance / CircleDiameter);
        }
    }

    internal void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, _positions[_positions.Count - 1], Quaternion.identity, transform);
        _snakeCircles.Add(circle);
        _positions.Add(circle.position);
    }

    internal void RemoveCircle()
    {
        Destroy(_snakeCircles[0].gameObject);
        _snakeCircles.RemoveAt(0);
        _positions.RemoveAt(1);
    }
}
