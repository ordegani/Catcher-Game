using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Character component
//methods:
//√-control position; Here is up to you which aproach to select (two fixed location: left and right; or it could be just horizontal
//- control elements catching; Once Item touch Character or Floor - it should reset the Item and drop it again from the top.

public class Character : MonoBehaviour
{
    [SerializeField] GameObject _planeCharacter;
    private Transform _transform;
    private Vector3 _currentPlaneCharacterPosition;

    void Start()
    {
        _transform = transform;
    }

    void Update()
    {
        MovePlaneCharacter();
    }

    void MovePlaneCharacter()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _currentPlaneCharacterPosition.x += 0.01f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _currentPlaneCharacterPosition.x -= 0.01f;
        }
        _transform.position = _currentPlaneCharacterPosition;
    }
}
