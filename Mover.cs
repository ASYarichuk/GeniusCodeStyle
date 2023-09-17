using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private int _currentPoint;

    private float _time;

    private Transform[] _pointsPath;

    private void Start()
    {
        _pointsPath = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _pointsPath[i] = _path.GetChild(i).transform;
    }

    private void Update()
    {
        var _targetPoint = _pointsPath[this._currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _time * Time.deltaTime);

        if (transform.position == _targetPoint.position) 
            SelectNextPoint();
    }

    private Vector3 SelectNextPoint()
    {
        _currentPoint++;

        if (_currentPoint == _pointsPath.Length)
            _currentPoint = 0;

        var targetPosition = _pointsPath[_currentPoint].transform.position;

        transform.forward = targetPosition - transform.position;

        return targetPosition;
    }
}