using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This component should have methods: 
//-activate / deactivate; (why do we need deactivation?)
//-reset;
//-random initialized position.


public class Items : MonoBehaviour
{
    [SerializeField] private GameObject _cubeItemPrefab;
    [SerializeField] private List<GameObject> _cubePool = new List<GameObject>();
    private int _poolSize = 5;
    private Transform _transform;
    private GameObject _cubeItem;

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

    void Update()
    {
  
    }

    IEnumerator HandleCubeItems()
    {
        while (true)
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
}

//make the cubes' colors random using MaterialPropertyBlock
//private void RandoiseColor(GameObject _cubeItem)
//{
//    MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
//    propertyBlock.SetColor("_Color", Random.ColorHSV());
//    _cubeItem.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
//}