using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject levelSel;
    [SerializeField] private GameObject buttonPrompt;
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button extraButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private GameObject nameInput;
    [SerializeField] private GameObject settingPage;
    [SerializeField] private EventBroadcast eventBroadcast;
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

        if (string.IsNullOrEmpty(systemSetting.userName))
        {
            nameInput.SetActive(true);
        }
        UpdateName();
        eventBroadcast.changeName += UpdateName;
    }
    private void OnDisable()
    {
        eventBroadcast.changeName -= UpdateName;
    }
    private void Update()
    {
        // Temporarily disable leader board
        //if (systemSetting.PressStart() && !nameInput.activeSelf)
        //{
        //    nameInput.SetActive(true);
        //}
    }
    private void UpdateName()
    {
        userName.text = "Name: " + systemSetting.userName; // + " (Press <sprite name=Start> to change)";
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
