using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    public GameObject egg;
    List<GameObject> pool = new List<GameObject>();
    public int size = 30;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i< size; i++)
        {
            GameObject clone = Instantiate(egg, this.transform);
            clone.gameObject.SetActive(false);
            pool.Add(clone);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach(GameObject obj in pool)
        {
            if(!obj.activeInHierarchy)
                return obj;
        }
        GameObject newClone = Instantiate(egg, this.transform);
        newClone.gameObject.SetActive(false);
        pool.Add(newClone);
        return newClone;
    }
}
