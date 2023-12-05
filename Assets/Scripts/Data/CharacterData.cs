using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Character",menuName = "Create New Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] public Type_Character tag;
    [SerializeField] public int hp;
    [SerializeField] public int atk;

    [SerializeField] int multipleHp;
    [SerializeField] int mulyipleAtk;

    private int currentHp;
    private int maxHp;
    private int currentAtk;

    public int PlayerLevel
    {
        get => PlayerPrefs.GetInt(name + tag.ToString(), 1);
        set =>PlayerPrefs.SetInt(name + tag.ToString(), value);
    }
    public void SetupAttribute()
    {
        maxHp = hp + multipleHp * PlayerLevel;
        currentHp = maxHp;
        currentAtk = atk +mulyipleAtk*PlayerLevel;
    }
    public void UpLevel(Action callback = null)
    {
        PlayerLevel++;
        callback?.Invoke();
    }
    public void AdjustHp(int val, Action<bool> isDie)
    {
        currentHp += val;
        if (currentHp <= 0)
        {
            currentHp = 0;
            isDie?.Invoke(true);
            return;
        }
        else if (currentHp >= maxHp) currentHp = maxHp;
        isDie?.Invoke(false);
    }
}
