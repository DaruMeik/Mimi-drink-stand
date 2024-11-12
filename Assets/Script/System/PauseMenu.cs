using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingPage;
    [SerializeField] private GameObject firstSelectedObj;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private EventBroadcast eventBroadcast;
    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(firstSelectedObj);
    }
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
