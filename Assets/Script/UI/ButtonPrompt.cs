using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPrompt : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject prompt;
    public void OnEnable()
    {
        eventSystem = EventSystem.current;
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
    public void OnPointerEnter(PointerEventData eventData)
    {
        eventSystem.SetSelectedGameObject(gameObject);
    }
}
