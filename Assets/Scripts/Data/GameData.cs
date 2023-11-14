using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
}
public enum Type_Character
{
    Player,
    Enemy,
}
public struct Game_Tag
{
    public const string Player = "Player";
    public const string Enemy = "Enemy";
    public const string Point = "Point";
}
public enum Type_Attack
{
    Melee,
    Range
}