using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRecipe : MonoBehaviour
{
    [SerializeField] private GameObject recipe;
    [SerializeField] private GameObject recipeTut;
    [SerializeField] private GameObject firstOrder;
    [SerializeField] private GameObject hypeMeter;
    [SerializeField] private SystemSetting systemSetting;
    private void Update()
    {
        if (recipe.activeSelf || systemSetting.finishFirstDay)
        {
            recipeTut.SetActive(false);
            firstOrder.SetActive(true);
            hypeMeter.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
