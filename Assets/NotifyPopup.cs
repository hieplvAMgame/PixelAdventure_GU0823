using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotifyPopup : PopupUI<NotifyPopup>
{
    public Button btnClose;

    protected override void Awake()
    {
        base.Awake();
        btnClose.onClick.AddListener(Close);
    }
}
