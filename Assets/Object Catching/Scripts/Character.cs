using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Character component
//methods:
//√-control position; Here is up to you which aproach to select (two fixed location: left and right; or it could be just horizontal
//- control elements catching; Once Item touch Character or Floor - it should reset the Item and drop it again from the top.

public class Character : MonoBehaviour //todo: better to use namespace 
{
    [SerializeField] GameObject _planeCharacter; //todo: you have this plane, but didn't use it
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
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _currentPlaneCharacterPosition.x += 0.01f;
=======
#region another way to do

        // better to use this approach:
        // it's not a mistake, it's just different. and in my opinion much better
        
        // _currentPlaneCharacterPosition = _transform.position;
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     _currentPlaneCharacterPosition.x += 0.01f; 
        // }
        //
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     _currentPlaneCharacterPosition.x -= 0.01f; 
        // }
        //  
        // _transform.position = _currentPlaneCharacterPosition;
        
#endregion

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //todo: with this calculation there are a chance to go out of the screen
            _currentPlaneCharacterPosition.x += 1; 
>>>>>>> ecff63adaa35bdf947fa50f181fe4cbb643bb9ec
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
<<<<<<< HEAD
            _currentPlaneCharacterPosition.x -= 0.01f;
        }
        _transform.position = _currentPlaneCharacterPosition;
=======
            //todo: with this calculation there are a chance to go out of the screen
            _currentPlaneCharacterPosition.x -= 1;
        }
        
        _transform.position = new Vector3(_currentPlaneCharacterPosition.x, _transform.position.y, _transform.position.z);
        
        // todo: to not allow to go out of the screen you can use Mathf.Clamp(_currentPlaneCharacterPosition.x, _minimalValueOfTheScreen, _maximumValueOfTheScreen);
        // and then apply it to the _transformPosition
        
>>>>>>> ecff63adaa35bdf947fa50f181fe4cbb643bb9ec
    }
}
