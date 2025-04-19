using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Character component
//methods:
//-control position; Here is up to you which aproach to select (two fixed location: left and right; or it could be just horizontal
//- control elements catching; Once Item touch Character or Floor - it should reset the Item and drop it again from the top.

public class Character : MonoBehaviour
{
    [SerializeField] GameObject _planeCharacter;
    private Transform _transform;
    private Vector3 _currentPlaneCharacterPosition;

    void Start()
    {
        _transform = transform;
        _transform.position = _currentPlaneCharacterPosition;
    }

    void Update()
    {
        MovePlaneCharacter();
    }

    void MovePlaneCharacter()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentPlaneCharacterPosition.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentPlaneCharacterPosition.x -= 1;
        }
        _transform.position = new Vector3(_currentPlaneCharacterPosition.x, _transform.position.y, _transform.position.z);
    }
}
