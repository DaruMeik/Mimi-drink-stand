using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private EventBroadcast eventBroadcast;
    private void OnEnable()
    {
        eventBroadcast.changeVolume += ChangeVolume;
    }
    private void OnDisable()
    {
        eventBroadcast.changeVolume -= ChangeVolume;
    }
    private void ChangeVolume()
    {
        audioSource.volume = systemSetting.masterVolume * systemSetting.bgmVolume;
    }
}
