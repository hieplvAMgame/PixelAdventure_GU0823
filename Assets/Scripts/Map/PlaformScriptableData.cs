using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Data Plaform", menuName = "Create New Data Plaform")]
public class PlaformScriptableData : ScriptableObject
{
    [Header("ITEM")]
    public int value;
    // TYPE ITEM: HP, DAME, BAT TU,...
    [Header("Buff")]
    // TYPE: SPEED, JUMP
    public float multiple;
    public float duration;
    [Header("Trap")]
    public float trapDame;
    [Header("None")]
    public float speed;
}
public enum Type_Plaform
{
    Item,
    Trap,
    Buff,
    None
}
