using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class HpBarUI : MonoBehaviour
{
    int maxValue;
    int currentValue;
    public Image fillImage;
    void OnInit(int maxValue)
    {
        this.maxValue = maxValue;
        currentValue = maxValue;
    }
    public void OnChangeHP(int value)
    {
        int targetVal = currentValue + value;
        if (targetVal > maxValue)
            targetVal = maxValue;
        else if (targetVal < 0)
            targetVal = 0;
        fillImage.DOFillAmount(targetVal, .3f);
    }
}
