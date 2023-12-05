using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Item", menuName = "New Item Data")]
public class IItem : ScriptableObject
{
    public Type_Item itemType;
    public int val;

    public void OnCollect(Action callback =null)
    {
        Debug.Log($"Contact with Player by type = {itemType}");
        switch (itemType)
        {
            case Type_Item.Hp:
                Player.instance.data.AdjustHp(val, (isDie) =>
                {
                    if (isDie)
                    {
                        // Do some thing when die
                    }
                    else
                    {
                        // Do some thing if not die
                    }
                });
                break;
            case Type_Item.Atk:break;
            case Type_Item.Coin:
                // Add coin
                break;
        }
    }
}
public enum Type_Item
{
    Atk,
    Hp,
    Coin,
}
