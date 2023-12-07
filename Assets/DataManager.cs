using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public ICurrency coinCurrency = new ICurrency();
    public ICurrency gemCurrency = new ICurrency();
    public override void Awake()
    {
        base.Awake();
        coinCurrency.SetupDefault("Coin", 1000);
        gemCurrency.SetupDefault("Gem", 300);
    }
    const string StrIsShowTutorial = "IsShowTuturial";
    public bool IsShowTutorial
    {
        get => PlayerPrefs.GetInt(StrIsShowTutorial, 0) == 1;
        set => PlayerPrefs.SetInt(StrIsShowTutorial, value ? 1 : 0);
    }
}
