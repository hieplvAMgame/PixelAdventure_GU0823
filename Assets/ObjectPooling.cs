using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    public GameObject egg;
    Stack<GameObject> pool = new Stack<GameObject>();
    public int size = 30;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreatePool();
    }
    void CreatePool()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject clone = Instantiate(egg, this.transform);
            clone.SetActive(false);
            pool.Push(clone);
        }
    }
    GameObject _temp;
    public GameObject GetObjectFromPool()
    {
        if (pool.Count > 0)
        {
            _temp = pool.Pop();
            return _temp;
        }
        GameObject newClone = Instantiate(egg, this.transform);
        newClone.SetActive(false);
        return newClone;
    }
    public void ReturnObjToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }
}

// Object.Instance.ReturnObjToPool(gameObject);
