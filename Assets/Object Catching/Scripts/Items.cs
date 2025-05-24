using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private GameObject _cubeItemPrefab;
    [SerializeField] private List<GameObject> _cubePool = new List<GameObject>();
    private GameObject _cubeItem;
    private int _poolSize = 5;
    private Transform _transform;

    void Start()
    {
        addToPool();
        StartCoroutine(ActivateItem());
    }

    void Update()
    {
        //Check if item hits ground/character it is being deativated
    }

    void addToPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject _cubeItem = Instantiate(_cubeItemPrefab, new Vector3(Random.Range(-10, 11), 3, 1), Quaternion.identity);
            _cubeItem.SetActive(false);
            _cubePool.Add(_cubeItem);
        }
    }
    IEnumerator ActivateItem()
    {
        foreach (GameObject Item in _cubePool)
        {
            Item.SetActive(true);
            yield return new WaitForSeconds(10f);

        }
    }
    //If item hits ground/character it is being deactivated
    void DeActivate()
    {
        _cubeItem.SetActive(false);
    }
}
