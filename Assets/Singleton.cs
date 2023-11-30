using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: Component
{
    public static T instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
        }
        else
            DestroyImmediate(this);
    }
}
