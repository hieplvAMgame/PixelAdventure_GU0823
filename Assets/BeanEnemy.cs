using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanEnemy : MonoBehaviour
{
    [Header("BULLET")]
    public GameObject bullet;
    public float bulletSpeed;
    public Transform shootingPoint;
    //public float delayTime = 1;
    float count = 0;
    Enemy enemy;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    public void Shoot()
    {
        GameObject clone = Instantiate(bullet,shootingPoint.position,Quaternion.identity);
        clone.TryGetComponent(out Bullet bl);
        bl.Setup(true, bulletSpeed,enemy.isFacingRight);
    }
    
}
