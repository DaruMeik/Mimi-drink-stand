using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private DayLogic dayLogic;
    [SerializeField] private EventBroadcast eventBroadcast;
    private void OnEnable()
    {
        eventBroadcast.changeToHP += UpdateHP;
    }
    private void OnDisable()
    {
        eventBroadcast.changeToHP -= UpdateHP;
    }
    private void UpdateHP()
    {
        for(int i = 0; i < 3; i++)
        {
            if(i  < dayLogic.HP)
                hearts[i].SetActive(true);
            else
                hearts[i].SetActive(false);
        }
    }
}
