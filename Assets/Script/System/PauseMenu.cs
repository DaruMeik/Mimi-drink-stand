using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingPage;
    [SerializeField] private EventBroadcast eventBroadcast;
    public void OnDisable()
    {
        settingPage.SetActive(false);
    }
    public void Setting()
    {
        settingPage.SetActive(true);
    }
    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void Back()
    {
        eventBroadcast.TurnOffPauseMenuNoti();
    }
}
