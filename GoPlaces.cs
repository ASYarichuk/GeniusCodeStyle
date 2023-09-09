using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    private int _numberOfPlaceInArrayPlaces;

    private float _time;

    private Transform _allPlacesPoint;

    private Transform[] _arrayPlaces;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        var _pointByNumberInArray = _arrayPlaces[_numberOfPlaceInArrayPlaces];

        transform.position = Vector3.MoveTowards(transform.position, _pointByNumberInArray.position, _time * Time.deltaTime);

        if (transform.position == _pointByNumberInArray.position) 
            NextPlaceTakerLogic();
    }

    private Vector3 NextPlaceTakerLogic()
    {
        _numberOfPlaceInArrayPlaces++;

        if (_numberOfPlaceInArrayPlaces == _arrayPlaces.Length)
            _numberOfPlaceInArrayPlaces = 0;

        var thisPointVector = _arrayPlaces[_numberOfPlaceInArrayPlaces].transform.position;

        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}