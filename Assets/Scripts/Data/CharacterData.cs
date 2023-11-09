using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Character",menuName = "Create New Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] public Type_Character tag;
    [SerializeField] public int hp;
    [SerializeField] public int atk;
}
