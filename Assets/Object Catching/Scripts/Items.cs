using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//This component should have methods: 
//-reset;
//-random initialized position.
//-activate / deactivate; (why do we need deactivation?) //todo: activate - it should activate the object from the pool;
//todo: deactivate - deactivation the object from the pool. To use later.  

#region Hint

// the main sense of the pool object pattern, in example: 
// we have an array of 10 objects;
// we take 1st not busy object 
// do some action and mark it as "busy"
// once it finished the action, we mark it as "non busy" and return it to the default position

// in our example it should be something like (it's not our example, but the idea should be +-clear)
// once "rain drop" was launched from the "cloud" it is - BUSY
// if I want in this frame launch another one - I can take the second one, which is also become "BUSY"
// once "rain drop" touched the ground -> it returns in the cloud and marked as NON BUSY
// so the next frame can reuse the first "rain drop" (because it's not busy anymore)

#endregion


public class Items : MonoBehaviour
{
    [SerializeField] private GameObject _cubeItemPrefab;
    [SerializeField] private List<GameObject> _cubePool = new List<GameObject>();
    private int _poolSize = 5;
    private Transform _transform;
    private GameObject _cubeItem;

#region Pool object best practice

    /*
 * for the best practice is better to create pool at start.
 * your game at the moment don't need to contain a lot of objects so it could be done in a few ways:
 * 1) you create all items in the Unity Inspector and then use it
 * 2) you can set _poolSize and at start fill them all. (what you do in the addToPool() but call it only at Start.
 * 3) maybe the better one is to combine 1 and 2 methods. But for now use only 1 or 2.
 */

#endregion

    void Start()
    {
        _transform = transform;
        //Creating the pool
        addToPool();
        StartCoroutine(HandleCubeItems());
        //Option:
        //IEnumerator SpawnCubesOneByOne()
        //{
        //    foreach (GameObject item in _cubePool)
        //    {
        //        item.SetActive(true);
        //        yield return new WaitForSeconds(1f);
        //    }

        //    // Add more to the pool if needed
        //    AddToPool();

        //    // Restart the coroutine
        //    StartCoroutine(SpawnCubesOneByOne());
        //}

    }

#region Hint

    // [SerializeField] private float _timeForSpawn; //todo:
    // private float _timer;
    //
    // private void LateUpdate() // each last of the frame we are working here
    // {
    //     _timer += Time.deltaTime; // this is a delta time from Unity (the time of the one frame passing)
    //     if (_timer < _timeForSpawn)
    //     {
    //         return;
    //     }
    //
    //     _timer = 0f;
    //     LaunchObject(); // it's your method of launch object. Which will be taken an object from the bool and "sending it to the bottom"
    //                     // in this method you can adjust the position of the object.
    //                     // so instead of the  Instantiate(_cubeItemPrefab, new Vector3(Random.Range(-10, 11), 3, 1), Quaternion.identity);
    //                     // you can use _objectFromPool.transform.position =  new Vector3(Random.Range(-10, 11), 3, 1);
    //
    //                     // but again, it's better to make it more flexible to not use Range(-10, 11); 3; or 1. 
    //                     // it could be: the values from Inspector; or calculated automatically; or at least you can move it to Constants. (this way later on you will be able to adjust it one place
    // and not looking in the whole file trying to find the proper one.  
    // }

#endregion

    void Update()
    {
    }

    IEnumerator HandleCubeItems()
    {
        while (true) // todo: this is not good. that means you will always have running coroutine 
        {
            List<GameObject> new__cubePoolCopy = new List<GameObject>(_cubePool);
            //use cubes from the pool
            foreach (GameObject Item in new__cubePoolCopy)
            {
                Item.SetActive(true);
                yield return new WaitForSeconds(1f);
                //RandoiseColor(Item);
            }

            //Create new cubes and add them to the pool, if there're no cubes left in it
            //GameObject new_cubeItem = Instantiate(_cubeItemPrefab, new Vector3(Random.Range(-10, 11), 3, 1), Quaternion.identity);
            //new_cubeItem.SetActive(false);

            //new__cubePoolCopy.Add(new_cubeItem);
            addToPool();
            foreach (GameObject Item in new__cubePoolCopy)
            {
                Item.SetActive(true);
                yield return new WaitForSeconds(1f);
                //RandoiseColor(Item);
            }
            //RandoiseColor(new_cubeItem);
        }
    }

    void addToPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject _cube = Instantiate(_cubeItemPrefab, new Vector3(Random.Range(-10, 11), 3, 1), Quaternion.identity);
            _cube.SetActive(false);
            _cubePool.Add(_cube);
        }
    }

#region Another Hint

    // when you instantiate object, or make some game, you need to specify the item from PoolObject or Instantiated.
    // For example, if it's a food failing from the sky:
    //          bread - could give you 10 points;
    //          ice cream - 50 points;
    // and you need somehow know what exactly you catch. 
    
    // also, you need to know when your object is touched the ground or the plane/character
    // to reset the behaviour of it's object.

#endregion
}

//make the cubes' colors random using MaterialPropertyBlock
//private void RandoiseColor(GameObject _cubeItem)
//{
//    MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
//    propertyBlock.SetColor("_Color", Random.ColorHSV());
//    _cubeItem.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
//}