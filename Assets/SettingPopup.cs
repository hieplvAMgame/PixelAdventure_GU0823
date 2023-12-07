using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : PopupUI<SettingPopup>
{
    public Button btnApply;
    public Button btnExit;

    public Slider sfxSlider;
    public Slider musicSlider;
    protected override void Awake()
    {
        base.Awake();

    }
    void AddListenner()
    {
        btnApply.onClick.AddListener(() =>
        {
            // what happen when btn apply is pressed
        });
        btnExit.onClick.AddListener(Close);
    }
}
