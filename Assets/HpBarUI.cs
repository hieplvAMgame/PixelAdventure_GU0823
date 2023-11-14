using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector.Editor;

public class HpBarUI : MonoBehaviour
{
    int maxValue;
    int currentValue;
    public Image imgHp;
    List<Image> images = new List<Image>();
    public void OnInit(int maxValue)
    {
        this.maxValue = maxValue;
        currentValue = maxValue;
        for(int i= 0; i < maxValue; i++)
        {
            Image img = Instantiate(imgHp, this.transform);
            img.gameObject.SetActive(true);
            images.Add(img);
        }
    }
    public void OnChangeHP(int value)
    {
        int targetVal = currentValue + value;
        if (targetVal > maxValue)
            targetVal = maxValue;
        else if (targetVal < 0)
            targetVal = 0;
        currentValue = targetVal;
        for(int i = 0; i < images.Count; i++)
        {
            if (i < currentValue)
                images[i].color = Color.white;
            else
                images[i].color = Color.black;
        }
    }
    public void OnAddMaxHp(int value)
    {
    }
}
