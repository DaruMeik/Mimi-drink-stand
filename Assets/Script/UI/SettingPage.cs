using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingPage : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private GameObject inputDisplay;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private SystemSetting systemSetting;
    private GameObject lastSelectedObj;
    private void OnEnable()
    {
        masterSlider.value = systemSetting.masterVolume;
        bgmSlider.value = systemSetting.bgmVolume;
        sfxSlider.value = systemSetting.sfxVolume;
        lastSelectedObj = eventSystem.currentSelectedGameObject;
        eventSystem.SetSelectedGameObject(masterSlider.gameObject);
    }
    private void OnDisable()
    {
        systemSetting.SaveGame();
        eventSystem.SetSelectedGameObject(lastSelectedObj);
    }
    private void Update()
    {
        if(eventSystem.currentSelectedGameObject == inputDisplay)
        {
            if(systemSetting.PressLeft() || systemSetting.PressRight() || systemSetting.PressSouth())
            {
                ChangeInput();
            }
        }
    }
    public void ChangeInput()
    {
        systemSetting.ChangeInput();
    }
    public void ChangeVolume()
    {
        systemSetting.ChangeVolume(masterSlider.value, bgmSlider.value, sfxSlider.value);
    }
    public void TurnOffPage()
    {
        gameObject.SetActive(false);
    }
}
