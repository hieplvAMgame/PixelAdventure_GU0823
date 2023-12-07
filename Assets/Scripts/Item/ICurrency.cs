using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICurrency
{
    private string saveString = "ICurrency";
    int defaultValue;
    int Value 
    {
        get => PlayerPrefs.GetInt(saveString, defaultValue);
        set => PlayerPrefs.SetInt(saveString, value <= 0 ? 0 : value);
    }
    public void SetupDefault(string name, int defaultValue)
    {
        this.defaultValue = defaultValue;
        saveString = string.Format($"{name} {saveString}");
    }
    public int GetValue() => Value;
    public void Add(int value) => Value += value;
    public void Minus(int value, Action<bool> canMinus = null)
    {
        if (Value >= value)
        {
            Value -= value;
            canMinus?.Invoke(true);
        }
        else
            canMinus?.Invoke(false);
    }
}
