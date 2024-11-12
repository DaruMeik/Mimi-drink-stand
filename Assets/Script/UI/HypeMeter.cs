using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HypeMeter : MonoBehaviour
{
    [SerializeField] private Slider hypeSlider;
    [SerializeField] private TextMeshProUGUI mult_text;
    [SerializeField] private DayLogic dayLogic;
    [SerializeField] private Image BG;
    [SerializeField] private Image fill;
    [SerializeField] private Sprite[] sliderFills;

    private void Update()
    {
        hypeSlider.value = dayLogic.hypeMeter % 1;
        mult_text.text = "x" + dayLogic.hypeMultiplier.ToString("F2");
        int index = Mathf.FloorToInt(dayLogic.hypeMeter);
        BG.sprite = sliderFills[index];
        fill.sprite = sliderFills[index+1];
    }
}
