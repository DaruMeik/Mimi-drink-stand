using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject levelSel;
    [SerializeField] private GameObject buttonPrompt;
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button extraButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject settingPage;
    public void OnEnable()
    {
        Navigation newGameNav = new Navigation(), quitNav = new Navigation();
        newGameNav.mode = Navigation.Mode.Explicit;
        quitNav.mode = Navigation.Mode.Explicit;

        newGameNav.selectOnDown = settingButton;
        quitNav.selectOnLeft = settingButton;

        if (!systemSetting.finishBaseGame)
        {
            extraButton.interactable = false;
        }
        else
        {
            extraButton.interactable = true;
            newGameNav.selectOnRight = extraButton;
            quitNav.selectOnUp = extraButton;
        }
        newGameButton.navigation = newGameNav;
        quitButton.navigation = quitNav;
    }
    public void NewGame()
    {
        levelSel.SetActive(true);
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
        Debug.Log("Quitting!");
        Application.Quit();
    }
}
