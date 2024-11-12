using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPrompt : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private GameObject prompt;
    public void OnEnable()
    {
        prompt.SetActive(false);
    }
    public void OnSelect(BaseEventData eventData)
    {
        prompt.SetActive(true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        prompt.SetActive(false);
    }
}
