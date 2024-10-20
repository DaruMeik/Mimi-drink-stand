using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button extraButton;
    [SerializeField] private GameObject settingPage;
    public void OnEnable()
    {
        if (systemSetting.currentRound == 0)
            continueButton.interactable = false;
        else
            continueButton.interactable = true;
        if(!systemSetting.finishBaseGame)
            extraButton.interactable = false;
        else
            extraButton.interactable = true;

    }
    public void NewGame()
    {
        systemSetting.NewGame();
        Continue();
    }
    public void Continue()
    {
        SceneManager.LoadScene("Day" + systemSetting.currentRound);
    }
    public void Extra()
    {
        SceneManager.LoadScene("Extra");
    }
    public void Setting()
    {
        settingPage.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
