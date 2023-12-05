using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHelper : MonoBehaviour
{
    public static GameObject ShowPopUp(string name, Transform parent = null, Action callback = null)
    {
        if (parent == null)
            parent = GameObject.Find("Popups").transform;
        if (parent)
        {
            GameObject ret = Instantiate(Resources.Load<GameObject>("Popups/" + name), parent);
            callback?.Invoke();
            return ret;
        }
        return null;
    }
    public static GameObject ShowPopUpWithCloseCallback<T>(string name, Transform parent = null, Action callback = null) where T : PopupUI<T>
    {
        if (parent == null)
            parent = GameObject.Find("Popups").transform;
        if (parent)
        {
            //hard code
            GameObject res = Resources.Load<GameObject>("Popups/" + name);
            GameObject ret = Instantiate(res, parent);
            ret.GetComponent<T>().OnClose = callback;
            return ret;
        }
        return null;
    }
}
