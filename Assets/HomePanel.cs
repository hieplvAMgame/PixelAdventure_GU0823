using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{
    public Button btnPlay;
    public Button btnSetting;
    public Button btnExit;

    public Text txtCoin;

    private void Awake()
    {
        btnPlay.onClick.AddListener(() =>
        {
            // LevelManager.Instance.LoadLevel(currentLevel)
        });
        btnSetting.onClick.AddListener(() =>
        {
            UIHelper.ShowPopUp(POPUP_NAME.SettingPopup);
        });
        btnExit.onClick.AddListener(() => { });
    }
    private void OnEnable()
    {
        LoadingScreen.instance.ActiveScene();
    }
    public void UpdateTextCoin()
    {
        txtCoin.text = DataManager.instance.coinCurrency.GetValue().ToString();
    }
}
