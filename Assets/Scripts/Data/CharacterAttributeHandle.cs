using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributeHandle
{
    Type_Character type;
    int hp;
    int currentHp;
    int atk;
    public CharacterAttributeHandle(CharacterData characterData)
    {
        hp = characterData.hp;
        atk = characterData.atk;
        type = characterData.tag;
    }
    public void Init()
    {
        currentHp = hp;
    }
    public int GetAtk() => atk;
    public void TakenDame(int amount, Action<bool> callback = null)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            Debug.LogError("Die");
            currentHp = 0;
            //OnDead();
            callback(true);
        }
        else
        {
            //OnTakenDamage();
            callback(false);
        }
    }
    //public virtual void OnDead()
    //{
    //    //
    //}
    //public virtual void OnTakenDamage()
    //{
    //    //
    //}

}
