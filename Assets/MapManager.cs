using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] Transform playerStartPoint;
    [SerializeField] List<Transform> enemyTransforms = new List<Transform>();
    /// <summary>
    /// Call when game in prepare state, for instantiate player and enemy
    /// </summary>
    public void OnInit()
    {
        Player.instance.transform.position = playerStartPoint.position;
        //
        // Spawn enemy theo enemyTransforms
        //
    }
}
