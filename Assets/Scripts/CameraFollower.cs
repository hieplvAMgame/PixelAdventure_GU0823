using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    [Range(0f, 1f)]
    public float smoothTime;
    public Vector2 limitX;
    public Vector2 limitY;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }
    Vector3 velo;
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position + offset;
        targetPos.x = Mathf.Clamp(targetPos.x, limitX.x, limitX.y);
        targetPos.y = Mathf.Clamp(targetPos.y, limitY.x, limitY.y);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velo, smoothTime);
    }
}
