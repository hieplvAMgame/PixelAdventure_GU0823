using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class DemoManage : MonoBehaviour
{
    public List<Demo> gameObjects = new List<Demo>(4);
    public List<Transform> transforms = new List<Transform>(4);
    void Awake()
    {

    }
    private void Start()
    {
        this.WaitForSeconds(2, () =>
        {
            foreach(var item in gameObjects)
            {
                item.MoveFollowList(transforms, 2);
            }
        });
    }

}
