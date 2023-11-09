
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] CharacterData data;
    public CharacterAttributeHandle characterAttributeHandle;
    private void Awake()
    {
        characterAttributeHandle = new CharacterAttributeHandle(data);
        characterAttributeHandle.Init();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
