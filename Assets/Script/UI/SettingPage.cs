using UnityEngine;
using UnityEngine.UI;

public class SettingPage : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SystemSetting systemSetting;
    private void OnEnable()
    {
        slider.value = systemSetting.volume;
    }
    public void ChangeVolume()
    {
        systemSetting.ChangeVolume(slider.value);
    }
    public void TurnOffPage()
    {
        gameObject.SetActive(false);
    }
}
